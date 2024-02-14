using AspNetCoreHero.Results;
using Code_Challenge_Core_Web_API.Models;

namespace Code_Challenge_Core_Web_API.Interfaces
{
    public interface ISchoolManagementInfo
    {
        Task<Result<OutputModel>> GetStudentsInfo(string directoryPath, string inputFilename, string outputFileName);
    }
}
