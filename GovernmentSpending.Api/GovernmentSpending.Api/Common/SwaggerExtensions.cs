namespace GovernmentSpending.Api.Common
{
    public class SwaggerExtensions
    {
        public static void AddSwaggerXml(Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions c)
        {
            var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
            foreach(var xmlFile in xmlFiles)
            {
                c.IncludeXmlComments(xmlFile);
            }
        }
    }
}
