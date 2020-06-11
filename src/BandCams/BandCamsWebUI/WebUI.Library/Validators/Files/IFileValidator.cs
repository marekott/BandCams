namespace WebUI.Library.Validators.Files
{
    public interface IFileValidator
    {
        string GetMaxFileSizeInMb { get; }
        string GetPermittedExtensions { get; }
        bool ValidateExtension(string fileName);
        bool ValidateSignature(string fileName, byte[] binaryFile);
        bool ValidateSize(long fileSizeInBytes);
    }
}