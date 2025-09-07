namespace STANWEBAPI.Constants
{
    public static class ApplicationErrorMessages
    {
        public const string GenericMessage = "Something Went Wrong";
        public const string BadModel = "The provided request model is not the expected model";
        public const string SAIdOrPassportNotBoth = "Only The SA ID Number or Passport Number is needed, not both";

        //ideal we can return a link to the JSON spec but this is alright for now.
        public static string BadModelErrorsContent(string modelName) => $"Provide model that abids to the class: {modelName} constraints";
    }
}