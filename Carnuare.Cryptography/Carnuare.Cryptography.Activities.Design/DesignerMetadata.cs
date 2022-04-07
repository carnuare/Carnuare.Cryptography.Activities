using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using Carnuare.Cryptography.Activities.Design.Designers;
using Carnuare.Cryptography.Activities.Design.Properties;

namespace Carnuare.Cryptography.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var categoryAttribute = new CategoryAttribute($"{Resources.Category}");

            builder.AddCustomAttributes(typeof(DecryptAES256GCM), categoryAttribute);
            builder.AddCustomAttributes(typeof(DecryptAES256GCM), new DesignerAttribute(typeof(DecryptAES256GCMDesigner)));
            builder.AddCustomAttributes(typeof(DecryptAES256GCM), new HelpKeywordAttribute(""));


            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
