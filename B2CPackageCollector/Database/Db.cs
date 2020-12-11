
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using B2CPackageCollect;
using Dapper;

// ReSharper disable AccessToDisposedClosure
namespace B2CPackageCollect
{
    public class Db : IDisposable
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        public Db(bool openTransaction = false)
        {
            _connection = CreateConnection();
            if (openTransaction)
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction();
            }
        }

        static Db()
        {
            SqlMapper.Settings.CommandTimeout = 300;
        }

        private static SqlConnection CreateConnection(string serverName, string databaseName, string userName, string password)
        {
            return new SqlConnection($"Server={serverName};Database={databaseName};User Id={userName};Password={password};");
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection($"Server={AppContext.User.ServerName};Database={AppContext.User.DatabaseName};User Id={AppContext.User.UserName};Password={AppContext.User.Password};");
        }

        public void Commit()
        {
            _transaction?.Commit();
        }

        public static void Login(string serverName, string databaseName, string userName, string password)
        {
            using (var connection = CreateConnection(serverName, databaseName, userName, password))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    throw new B2CPackageCollectException("Bağlantı sağlanamadı! Lütfen girilen bilgileri kontrol edip tekrar deneyiniz.");
                }
            }
        }

        public ProductWithInvoice GetProductWithInvoice(string barcode, FilterParameters filter)
        {
            var itemInfoParameters = new Dictionary<string, object>
            {
                { "Barcode", barcode }
            };

            var product = _connection.WithRetry(p => p.QueryFirstOrDefault<Product>("qry_GetB2CItemInfo", Utils.ToDynamicParameters(itemInfoParameters), commandType: CommandType.StoredProcedure));

            var invoiceParameters = new Dictionary<string, object>
            {
                { "Barcode", barcode },
                { "StoreCode", filter.StoreCode },
                { "StartDate", filter.StartDate },
                { "EndDate", filter.EndDate }
            };

            var invoiceHeader = _connection.WithRetry(p => p.QueryFirstOrDefault<InvoiceHeader>("qry_GetB2CInvoices", Utils.ToDynamicParameters(invoiceParameters), commandType: CommandType.StoredProcedure));

            if (string.IsNullOrWhiteSpace(invoiceHeader?.AlisverisID))
            {
                return new ProductWithInvoice(product, null, null);
            }

            var invoiceLineParameters = new Dictionary<string, object>
            {
                { "AlisverisID", invoiceHeader.AlisverisID }
            };

            var invoicesLines = _connection.WithRetry(p => p.Query<InvoiceLine>("qry_GetB2CInvoiceLines", Utils.ToDynamicParameters(invoiceLineParameters), commandType: CommandType.StoredProcedure));
            return new ProductWithInvoice(product, invoiceHeader, invoicesLines);
        }

        public IEnumerable<CollectReportLine> GetCollectReport(FilterParameters filter)
        {
            var invoiceParameters = new Dictionary<string, object>
            {
                { "StoreCode", filter.StoreCode },
                { "StartDate", filter.StartDate },
                { "EndDate", filter.EndDate }
            };
            return _connection.WithRetry(p => p.Query<CollectReportLine>("qry_GetB2CInvoicesCollectedReport", Utils.ToDynamicParameters(invoiceParameters), commandType: CommandType.StoredProcedure));
        }

        public InvoiceDetailsForReturn GetInvoiceDetailsForReturn(string alisverisId, string user)
        {
            var parameters = new Dictionary<string, object>
            {
                { "AlisverisID", alisverisId },
                { "Kullanici", user }
            };
            return _connection.WithRetry(
                p =>
                {
                    var result = p.QueryMultiple("qry_GetB2CInvoiceDetailsForReturn", Utils.ToDynamicParameters(parameters), commandType: CommandType.StoredProcedure);
                    return new InvoiceDetailsForReturn(result.Read(), result.Read());
                });
        }

        public void SaveReturnInvoice(List<IDictionary<string, object>> insertTable)
        {
            foreach (var row in insertTable)
            {
                _connection.WithRetry(p => p.Execute("sp_InsertB2CReturnInvoices", Utils.ToDynamicParameters(row), commandType: CommandType.StoredProcedure, transaction: _transaction));
            }
        }

        public IEnumerable<CollectReportLine> GetNotCollectReport(FilterParameters filter)
        {
            var invoiceParameters = new Dictionary<string, object>
            {
                { "StoreCode", filter.StoreCode },
                { "StartDate", filter.StartDate },
                { "EndDate", filter.EndDate }
            };
            return _connection.WithRetry(p => p.Query<CollectReportLine>("qry_GetB2CInvoicesNotCollectedReport", Utils.ToDynamicParameters(invoiceParameters), commandType: CommandType.StoredProcedure));
        }

        public CollectSummary GetCollectSummary(FilterParameters filter)
        {
            var invoiceParameters = new Dictionary<string, object>
            {
                { "StoreCode", filter.StoreCode },
                { "StartDate", filter.StartDate },
                { "EndDate", filter.EndDate }
            };
            return _connection.WithRetry(p => p.QueryFirst<CollectSummary>("qry_GetB2CInvoicesCollectedSummary", Utils.ToDynamicParameters(invoiceParameters), commandType: CommandType.StoredProcedure));
        }

        public CollectSummary GetCollectLineSummary(FilterParameters filter)
        {
            var invoiceParameters = new Dictionary<string, object>
            {
                { "StoreCode", filter.StoreCode },
                { "StartDate", filter.StartDate },
                { "EndDate", filter.EndDate }
            };
            return _connection.WithRetry(p => p.QueryFirst<CollectSummary>("qry_GetB2CInvoicesCollectedLineSummary", Utils.ToDynamicParameters(invoiceParameters), commandType: CommandType.StoredProcedure));
        }


        public IEnumerable<Warehouse> GetWarehouses()
        {

            return _connection.WithRetry(p => p.Query<Warehouse>("qry_GetB2CWarehouse", commandType: CommandType.StoredProcedure));

        }

        public DataTable GetSaleInvoiceFormDatasource(string alisverisId)
        {

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"select* From vwParekendeFatura Where Fis_TanimlamaNo =@alisverisId";
                command.Parameters.AddWithValue("@alisverisId", alisverisId);
                using (var adapter = new SqlDataAdapter(command))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }

        }

        public void CancelCollect(string alisverisId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "AlisverisID", alisverisId }
            };

            var sqlMaster = "DELETE FROM CollectedProductsMaster Where  AlisverisID=@AlisverisID";
            _connection.WithRetry(p => p.Execute(sqlMaster, Utils.ToDynamicParameters(parameters), _transaction));
            var sqlDetail = "DELETE FROM CollectedProductsDetail Where  AlisverisID=@AlisverisID";
            _connection.WithRetry(p => p.Execute(sqlDetail, Utils.ToDynamicParameters(parameters), _transaction));
        }

        public bool InvoiceHasReturn(string alisverisId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "AlisverisID", alisverisId }
            };
            return _connection.WithRetry(p => p.ExecuteScalar<int>("qry_CheckB2CInvoiceReturns", Utils.ToDynamicParameters(parameters), commandType: CommandType.StoredProcedure, transaction: _transaction)) > 0;
        }

        public void UpdateInvoicePrinted(string alisverisId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "AlisverisID", alisverisId }
            };
            var sql = $"UPDATE CollectedProductsMaster SET IsPrinted=1 WHERE AlisverisID=@AlisverisID";
            _connection.WithRetry(p => p.Execute(sql, Utils.ToDynamicParameters(parameters), _transaction));
        }

        public void UpdateCollectCompleted(string alisverisId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "AlisverisID", alisverisId }
            };
            var sql = "UPDATE CollectedProductsMaster SET IsCompleted=1 WHERE AlisverisID=@AlisverisID";
            _connection.WithRetry(p => p.Execute(sql, Utils.ToDynamicParameters(parameters), _transaction));
        }

        public void UpdateCollectCompletedAndPrinted(string alisverisId, CollectCompleteType completeType)
        {
            var parameters = new Dictionary<string, object>
            {
                { "AlisverisID", alisverisId },
                { "CompleteType", completeType }
            };
            var sql = $"UPDATE CollectedProductsMaster SET IsCompleted=1,IsPrinted=1,CompleteType=@CompleteType WHERE AlisverisID=@AlisverisID";
            _connection.WithRetry(p => p.Execute(sql, Utils.ToDynamicParameters(parameters), _transaction));
        }

        public void InsertCollectCompletedAndPrinted(string alisverisId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "AlisverisID", alisverisId }
            };
            var sql = "UPDATE CollectedProductsMaster SET IsCompleted=1,IsPrinted=1 WHERE AlisverisID=@AlisverisID";
            _connection.WithRetry(p => p.Execute(sql, Utils.ToDynamicParameters(parameters), _transaction));
        }


        public void SaveCollectHeaderAndDetail(string alisverisId, bool completed, decimal islemId, decimal collectedQty)
        {
            SaveCollectHeader(alisverisId, completed);
            SaveCollectDetail(alisverisId, islemId, collectedQty);
        }

        public void SaveCollectHeader(string alisverisId, bool completed)
        {
            var masterParameters = new Dictionary<string, object>
            {
                { "CollectedProductsMasterID", SquentialGuid.NewGuid() },
                { "AlisverisID", alisverisId },
                { "IsCompleted", completed }
            };

            _connection.WithRetry(p => p.Execute("qry_InsertB2CCollectedHeader", Utils.ToDynamicParameters(masterParameters), commandType: CommandType.StoredProcedure, transaction: _transaction));
        }

        public void SaveCollectDetail(string alisverisId, decimal islemId, decimal collectedQty)
        {

            var detailparameters = new Dictionary<string, object>
            {
                { "CollectedProductsDetailID", SquentialGuid.NewGuid() },
                { "IslemID", islemId },
                { "CollectedQty", collectedQty },
                { "AlisverisID", alisverisId }
            };

            _connection.WithRetry(p => p.Execute("qry_InsertB2CCollectedDetail", Utils.ToDynamicParameters(detailparameters), commandType: CommandType.StoredProcedure, transaction: _transaction));
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue)
            {
                return;
            }
            if (disposing)
            {
                _transaction?.Dispose();
                _connection?.Dispose();
            }
            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            ;
        }

        #endregion
    }
}

public class ProductWithInvoice
{
    private readonly IEnumerable<InvoiceLine> _invoiceLines;

    public ProductWithInvoice(Product product, InvoiceHeader invoiceHeader, IEnumerable<InvoiceLine> invoiceLines)
    {
        Product = product;
        InvoiceHeader = invoiceHeader;
        _invoiceLines = invoiceLines;
    }

    public Product Product { get; }

    public InvoiceHeader InvoiceHeader { get; }

    public IEnumerable<InvoiceLine> InvoiceLines => _invoiceLines ?? Enumerable.Empty<InvoiceLine>();

    public InvoiceLine Collect()
    {
        foreach (var line in InvoiceLines)
        {
            if (line.StokKodu == Product.StokKodu && !line.AllCollected())
            {
                line.ToplananMiktar++;
                return line;
            }
        }
        return null;
    }

    public bool Completed()
    {
        return InvoiceLines.HasItem() && InvoiceLines.All(p => p.AllCollected());
    }

    public bool Printed()
    {
        return InvoiceHeader != null && InvoiceHeader.Yazdirildi;
    }

    public void SetPrinted()
    {
        if (InvoiceHeader != null)
        {
            InvoiceHeader.Yazdirildi = true;
        }
    }

    public bool Valid()
    {
        return InvoiceHeader != null && _invoiceLines.HasItem();
    }
}

public class FilterParameters
{
    public FilterParameters(string storeCode, DateTime startDate, DateTime endDate)
    {
        StoreCode = storeCode;
        StartDate = startDate;
        EndDate = endDate;
    }

    public string StoreCode { get; }

    public DateTime StartDate { get; }

    public DateTime EndDate { get; }
}

public class InvoiceDetailsForReturn
{
    public readonly List<IDictionary<string, object>> Lines;

    public readonly List<IDictionary<string, object>> Payments;

    public InvoiceDetailsForReturn(IEnumerable<dynamic> lines, IEnumerable<dynamic> payments)
    {
        lines = lines ?? Enumerable.Empty<IDictionary<string, object>>();
        payments = payments ?? Enumerable.Empty<IDictionary<string, object>>();

        Lines = lines.Cast<IDictionary<string, object>>().AsList();
        Payments = payments.Cast<IDictionary<string, object>>().AsList();
    }
}


public class CollectSummary
{
    public int Completed { get; set; }
    public int Waiting { get; set; }
    public int Missing { get; set; }
}
