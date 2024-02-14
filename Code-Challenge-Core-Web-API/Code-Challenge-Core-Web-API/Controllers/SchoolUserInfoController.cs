using Code_Challenge_Core_Web_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Code_Challenge_Core_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolStudentInfoController : ControllerBase
    {
        private readonly ISchoolManagementInfo _studentInfo;

        public SchoolStudentInfoController(ISchoolManagementInfo studentInfo)
        {
            this._studentInfo = studentInfo;
        }

        [HttpGet]
        [Route("GetUserInfo")]
        public async Task<IActionResult> GetStudentInfo(string directoryPath, string inputFilename, string outputFileName)
        {
            var studentRecord = await _studentInfo.GetStudentsInfo(directoryPath, inputFilename, outputFileName);
            return Ok(studentRecord);
        }
    }
}
