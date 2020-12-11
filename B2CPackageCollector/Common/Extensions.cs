using System;
using System.Collections;
using System.Data;
using DevExpress.Utils;
using DevExpress.Utils.VisualEffects;
using DevExpress.XtraEditors;

namespace B2CPackageCollect
{
    public static class Extensions
    {
        public static string StringEditValue(this BaseEdit edit)
        {
            return edit.EditValue?.ToString() ?? string.Empty;
        }
        public static void CreateValidationHints(this AdornerUIManager manager, string text, params BaseEdit[] edits)
        {

            foreach (var edit in edits)
            {
                var hint = new ValidationHint
                {
                    TargetElement = edit
                };
                hint.Properties.IndeterminateState.ShowBorder = DefaultBoolean.False;
                hint.Properties.ValidState.ShowBorder = DefaultBoolean.False;
                hint.Properties.InvalidState.Text = text;
                hint.Properties.InvalidState.HintLocation = ValidationHintLocation.Right;
                manager.Elements.Add(hint);
            }
        }

        public static bool SetValidationHintToInvalid(this AdornerUIManager manager, BaseEdit edit, string text = "")
        {
            foreach (var element in manager.Elements)
            {
                if (element is ValidationHint validation)
                {
                    if (ReferenceEquals(validation.TargetElement, edit))
                    {
                        var oldText = validation.Properties.InvalidState.Text;
                        try
                        {
                            if (!string.IsNullOrWhiteSpace(text))
                            {
                                validation.Properties.InvalidState.Text = text;
                            }
                            validation.Properties.State = ValidationHintState.Invalid;
                        }
                        finally
                        {
                            validation.Properties.InvalidState.Text = oldText;
                        }


                        return true;
                    }
                }

            }
            return false;
        }

        public static void SetValidationHintsToValid(this AdornerUIManager manager)
        {
            foreach (var element in manager.Elements)
            {
                if (element is ValidationHint validation)
                {

                    validation.Properties.State = ValidationHintState.Valid;
                }
            }
        }

        public static T WithRetry<T>(this IDbConnection connection, Func<IDbConnection, T> action)
        {
            return ExecutionPolicy.RetryOnSqlException.Execute(() => action(connection));
        }

        public static bool HasItem(this IEnumerable enumerable)
        {
            if (enumerable == null)
            {
                return false;
            }
            if (enumerable is ICollection collection)
            {
                return collection.Count > 0;
            }
            return enumerable.GetEnumerator().MoveNext();
        }
 
    }
}
