using AspNetCoreHero.Results;
using Code_Challenge_Core_Web_API.Interfaces;
using Code_Challenge_Core_Web_API.Models;
using Newtonsoft.Json;

namespace Code_Challenge_Core_Web_API.Services
{
    public class SchoolManagementInfoService : ISchoolManagementInfo
    {
        public async Task<Result<OutputModel>> GetStudentsInfo(string directoryPath, string inputFilename, string outputFileName)
        {
            // Directory path 
            string filePath = Path.Combine(directoryPath, inputFilename);

            // Read input JSON file
            string inputJson = File.ReadAllText(filePath);
            var inputData = JsonConvert.DeserializeObject<InputModel>(inputJson);

            var outputData = new OutputModel
            { 
                // Map fields from input to output
                source_id = inputData.LearnerId.ToString(),
                old_source_id = null, // Assuming this value is not available
                pupil_admission_number = inputData.LearnerCode,
                first_name = inputData.Forename,
                legal_first_name = inputData.LegalForename,
                middle_name = null, // Assuming this value is not available
                last_name = inputData.Surname,
                legal_last_name = inputData.LegalSurname,
                former_last_name = null, // Assuming this value is not available
                gender = inputData.gender,
                year_code = inputData.Year,
                year_group_source_id = "2018-1718", // Assuming this value is static
                dob = inputData.DateOfBirth,
                upn = inputData.UPN,
                former_upn = inputData.FormerUPN,
                uln = inputData.ULN,
                is_eal = inputData.EAL,
                free_meal = null,
                free_meal6 = null,
                fsm_review_date = null,
                ethnicity_code = null, // Assuming this value is not available
                is_pp = false, // Assuming this value is static
                service_child = inputData.ServiceChild,
                looked_after = false, // Assuming this value is not available
                ever_in_care = null, // Assuming this value is not available
                sen_category = inputData.SENProvisionDetails.Count > 0 ? inputData.SENProvisionDetails[0].ProvisionTypeCode : null,
                enrolment_status = inputData.EnrolementStatus,
                address_line_1 = inputData.AddressDetails.Count > 0 ? $"{inputData.AddressDetails[0].Number} {inputData.AddressDetails[0].Street}" : null,
                address_line_2 = inputData.AddressDetails.Count > 0 ? inputData.AddressDetails[0].Locality : null,
                town_city = inputData.AddressDetails.Count > 0 ? inputData.AddressDetails[0].Town : null,
                county = inputData.AddressDetails.Count > 0 ? inputData.AddressDetails[0].county : null,
                country = inputData.AddressDetails.Count > 0 ? inputData.AddressDetails[0].country : null,
                post_code = inputData.AddressDetails.Count > 0 ? inputData.AddressDetails[0].post_code : null,
                start_date = null, // Assuming this value is not available
                end_date = null, // Assuming this value is not available
                home_language_code = null, // Assuming this value is not available
                home_language_name = null, // Assuming this value is not available
                first_language_code = inputData.LanguageDetails.Count > 0 ? inputData.LanguageDetails[0].LanguageCode : null,
                first_language_name = null, // Assuming this value is not available
                proficiency_in_english_code = null, // Assuming this value is not available
                proficiency_in_english_name = null, // Assuming this value is not available
                nationalities = inputData.AddressDetails.Count > 0 ? inputData.AddressDetails[0].country : null,
                country_of_birth = inputData.AddressDetails.Count > 0 ? inputData.AddressDetails[0].country : null,
                photo_hash = null, // Assuming this value is not available
                nhs_number = null, // Assuming this value is not available
                is_pregnant = null, // Assuming this value is not available
                has_emergency_consent = null, // Assuming this value is not available
            };

            // Directory where we save the output
            string outputFilePath = Path.Combine(Path.GetDirectoryName(filePath), $"{outputFileName}.json");

            // Serializing the custom response object
            File.WriteAllText(outputFilePath, JsonConvert.SerializeObject(outputData));

            return Result<OutputModel>.Success(outputData, "Successfully parse the input_mis_data.json file and output the data in the same format as output_mis_data.json. You can view the file in the path you created" + outputFilePath);
        }
    }
}
