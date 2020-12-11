using System;
using System.ComponentModel;
using System.Drawing;
using DevExpress.Charts.Native;
using DevExpress.XtraCharts;

namespace B2CPackageCollect.Controls
{
    public partial class UcDashBoard : UcBase
    {
        public UcDashBoard()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            AppearanceControl();
            AddControlEventHandlers();
            LoadOrders();
            LoadLinest();
            base.Initialize();
        }

        private void AppearanceControl()
        {
            try
            {
                lcMain.BeginUpdate();
                InitChart(chartOrders, "Sipariş Bazında", 0, 0, 0);
                InitChart(chartLines, "Ürün Bazında", 0, 0, 0);
                Utils.SetGlobalAppearance(lcMain);
            }
            finally
            {
                lcMain.EndUpdate();
            }
        }

        private void AddControlEventHandlers()
        {
            btnRefresh.Click += (sender, args) => OnRefreshClick(args);
        }

        private void OnRefreshClick(EventArgs args)
        {
            using (new WaitFormScope())
            {
                LoadOrders(true);
                LoadLinest(true);
            }
        }

        private void LoadOrders(bool force = false)
        {
            var collectContext = AppContext.CollectContext;
            if (!force && collectContext.OperationContext.DashboardLoaded)
            {
                return;
            }
            CollectSummary summary = null;
            try
            {

                using (var db = new Db())
                {
                    summary = db.GetCollectSummary(new FilterParameters(collectContext.StoreCode, collectContext.StartDate, collectContext.EndDate));
                }

            }
            catch (Exception ex)
            {
                AppContext.ShowErrorMessage(ex.Message);
                AppContext.Logger.Error(ex);
            }

            SetChartValues(chartOrders, summary);

        }

        private void LoadLinest(bool force = false)
        {
            var collectContext = AppContext.CollectContext;
            if (!force && collectContext.OperationContext.DashboardLoaded)
            {
                return;
            }
            CollectSummary summary = null;
            try
            {

                using (var db = new Db())
                {
                    summary = db.GetCollectLineSummary(new FilterParameters(collectContext.StoreCode, collectContext.StartDate, collectContext.EndDate));
                }

            }
            catch (Exception ex)
            {
                AppContext.ShowErrorMessage(ex.Message);
                AppContext.Logger.Error(ex);
            }

            SetChartValues(chartLines, summary);

        }

        private void SetChartValues(ChartControl chart, CollectSummary summary)
        {
            if (summary == null)
            {
                summary = new CollectSummary();
            }

            chart.Series[0].Points[0].Values = new double[] { summary.Completed };
            chart.Series[0].Points[1].Values = new double[] { summary.Waiting };
            chart.Series[0].Points[2].Values = new double[] { summary.Missing };
        }

        private void InitChart(ChartControl chart, string title, int completedValue, int waitingValue, int missingValue)
        {
            var series = new Series();
            var seriesLabel = new PieSeriesLabel();
            var seriesCompleted = new SeriesPoint("Tamamlanan", new object[] { completedValue }, 0);
            var seriesWaiting = new SeriesPoint("Bekleyen", new object[] { waitingValue }, 1);
            var seriesMissing = new SeriesPoint("Eksik", new object[] { missingValue }, 2);
            var pieView = new PieSeriesView();
            var chartTitle = new ChartTitle();
            ((ISupportInitialize)chart).BeginInit();
            ((ISupportInitialize)series).BeginInit();
            ((ISupportInitialize)seriesLabel).BeginInit();
            ((ISupportInitialize)pieView).BeginInit();

            SuspendLayout();

            chart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            chart.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
            chart.Legend.Direction = LegendDirection.LeftToRight;
            chart.Legend.Name = "Default";
            chart.Legend.Font = AppAppearance.DefaultFont;
            chart.Location = new Point(12, 12);
            seriesLabel.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLabel.TextPattern = "{A} : {V} - {VP:0.0%}";
            seriesLabel.Font = AppAppearance.DefaultFont;
            seriesLabel.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAllAroundPoint;
            seriesLabel.ResolveOverlappingMinIndent = 5;
            series.Label = seriesLabel;
            series.Name = "Sipariş";
            seriesMissing.ColorSerializable = "#9BBB59";
            series.Points.AddRange(seriesCompleted, seriesWaiting, seriesMissing);
            series.View = pieView;
            chart.SeriesSerializable = new[] { series };
            chartTitle.Text = title;
            chart.Titles.AddRange(new[] { chartTitle });

            ((ISupportInitialize)seriesLabel).EndInit();
            ((ISupportInitialize)pieView).EndInit();
            ((ISupportInitialize)series).EndInit();
            ((ISupportInitialize)chart).EndInit();
            ResumeLayout(false);
        }

        public override void Activated()
        {
            using (new WaitFormScope())
            {
                LoadOrders();
                LoadLinest();
            }
            base.Activated();
        }
    }
}
