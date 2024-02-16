using AspNetCoreHero.Results;
using Code_Challenge_Core_Web_API.Interfaces;
using Code_Challenge_Core_Web_API.Models;
using Code_Challenge_Core_Web_API.Services;
using FluentAssertions;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_Unit_Test.SchoolManagement
{
    public class SchoolUserUnitTest
    {
        [Fact]
        public async void TestGetStudentsInfo()
        {
            // Arrange - variables , classes , method
            string directoryPath = "Task-Output"; // Name of the path file 
            string inputFilename = "input_mis_data.json"; // Name of the input JSON file
            string outputFilename = "MyOutputFile"; // Name of the output JSON file         
            string outputFileFormat = "output_mis_data.json"; // Name of the output JSON file format  

            // Mock ISchoolManagementInfo dependency
            var mockSchoolManagementInfo = new Mock<ISchoolManagementInfo>();
            mockSchoolManagementInfo.Setup(x => x.GetStudentsInfo(directoryPath, inputFilename, outputFilename))
                                     .ReturnsAsync(Result<OutputModel>.Success(new OutputModel(), "Success"));

            var service = new SchoolManagementInfoService();

            // Act - execute the method
            var result = await service.GetStudentsInfo(directoryPath, inputFilename, outputFilename);
            string filePathOutputResult = Path.Combine(directoryPath, outputFilename + ".json");
            string filePathOutputFormat = Path.Combine(directoryPath, outputFileFormat);

            JObject filePathOutputResultJson = JObject.Parse(File.ReadAllText(filePathOutputResult));
            JObject filePathOutputFormatJson = JObject.Parse(File.ReadAllText(filePathOutputFormat));

            // Check if the JSON files have the same format
            bool areEqual = JToken.DeepEquals(filePathOutputResultJson, filePathOutputFormatJson);

            // Assert whether the JSON files are equal
            Assert.True(areEqual, "The JSON files are not equal.");

            // Assert
            result.Should().NotBeNull();
            result.Succeeded.Should().BeTrue();
        }
    }
}
