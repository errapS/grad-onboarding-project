using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.Sqlite;
using Swashbuckle.AspNetCore.Annotations;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoAppController : ControllerBase
    {
        private IConfiguration _configuration;
        public TodoAppController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [SwaggerOperation(Summary = "Returns data on toxins derived from smoking.")]
        [HttpGet]
        [Route("GetToxinData")]
        public JsonResult GetToxinData()
        {
            string query = "select * from toxins";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("DBcon");
            SqliteDataReader myReader;
            using (SqliteConnection myCon = new SqliteConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqliteCommand myCommand = new SqliteCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [SwaggerOperation(Summary = "Returns descriptions for individual toxins, detailing their effects on the body.")]
        [HttpGet]
        [Route("GetToxinsDescriptions")]
        public JsonResult GetToxinsDescriptions()
        {
            // Implementation should provide descriptions of toxins and their effects on the body.
            throw new NotImplementedException("Endpoint not implemented yet");
        }

        [HttpPost]
        [Route("AddUser")]
        public JsonResult AddUser([FromForm] int numberOfDays, [FromForm] string type, [FromForm] int quantity, [FromForm] int totalSpent, [FromForm] int totalIfInvested)
        {
            // Implementation should add a new user, with the specified parameters, to a table in the sqlite database.
            throw new NotImplementedException("Endpoint not implemented yet");
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public JsonResult GetAllUsers()
        {
            // Implementation will retrieve all users from the database.
            throw new NotImplementedException("Endpoint not implemented yet");
        }

        [HttpGet]
        [Route("GetAllUsersCalculatedData")]
        public JsonResult GetAllUsersCalculatedData()
        {
            // Implementation will retrieve and summarize data from all the users in the database. 
            throw new NotImplementedException("Endpoint not implemented yet");
        }

        [HttpGet]
        [Route("GetAllUsersCalculatedDataByType/{type}")]
        public JsonResult GetAllUsersCalculatedDataByType(string type)
        {
            // Implementation will retrieve and summarize data from all the users in the database, type should either be 'Tobacco' or 'Electronic'. 
            throw new NotImplementedException("Endpoint not implemented yet");
        }

        [HttpGet]
        [Route("GetUserToxinsData{numberOfDays}/{type}/{quantity}/{priceToday}/{futureDays}")]
        public JsonResult GetUserToxinsData(int numberOfDays, string type, int quantity, int priceToday, int futureDays)
        {
            // Implementation will calculate and return the amount of toxins a user has consumed based on their input. 
            throw new NotImplementedException("Endpoint not implemented yet");
        }
    }
}