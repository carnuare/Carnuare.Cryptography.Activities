using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using Carnuare.Cryptography.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;

namespace Carnuare.Cryptography.Activities
{
    [LocalizedDisplayName(nameof(Resources.DecryptAES256GCM_DisplayName))]
    [LocalizedDescription(nameof(Resources.DecryptAES256GCM_Description))]
    public class DecryptAES256GCM : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.DecryptAES256GCM_String_DisplayName))]
        [LocalizedDescription(nameof(Resources.DecryptAES256GCM_String_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> String { get; set; }

        [LocalizedDisplayName(nameof(Resources.DecryptAES256GCM_Key_DisplayName))]
        [LocalizedDescription(nameof(Resources.DecryptAES256GCM_Key_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Key { get; set; }

        [LocalizedDisplayName(nameof(Resources.DecryptAES256GCM_Decrypted_DisplayName))]
        [LocalizedDescription(nameof(Resources.DecryptAES256GCM_Decrypted_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public OutArgument<string> Decrypted { get; set; }

        #endregion


        #region Constructors

        public DecryptAES256GCM()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (String == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(String)));
            if (Key == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(Key)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var cypherText = String.Get(context);
            var key = Key.Get(context);

            var res = "Cypher text: " + cypherText + " / Password: " + key;

            // Outputs
            return (ctx) => {
                Decrypted.Set(ctx, res);
            };
        }

        #endregion
    }
}

