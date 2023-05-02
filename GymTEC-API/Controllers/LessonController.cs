using GymTEC_API.Entidades;
using GymTEC_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GymTEC_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class LessonController:ControllerBase
    {
        //All classes para CLIENTES
        [HttpGet("all_classes")]
        public async Task<ActionResult<JSON_Object>> AllClasses()
        { //Function for obtaining all branch names.


            DataTable allClasses = DBData.GetAllClasses();

            List<Lesson_SHOWALL> branch_L = new List<Lesson_SHOWALL>();

            foreach (DataRow row in allClasses.Rows)
            {
                Lesson_SHOWALL lesson = new Lesson_SHOWALL();
                lesson.ID_Lessons = Convert.ToInt32(row["lesson_id"]);
                lesson.Branch_Name = row["branch_name"].ToString();
                lesson.instructor_id = row["instructor_id"].ToString();
                lesson.service_id = row["service_id"].ToString();
                lesson.Quotas = Convert.ToInt32(row["quotas"]);

                branch_L.Add(lesson);

            }

            JSON_Object json = new JSON_Object("ok", branch_L);
            return Ok(json);
        }
        [HttpPost("add_lesson")] //para admin
        public async Task<ActionResult<JSON_Object>> AddLesson(Lesson lesson_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteAddLesson(lesson_data);
            Console.WriteLine(var);
            if (var)
            {
                json.status = "ok";
                return Ok(json);
            }
            else
            {

                return BadRequest(json);
            }


        }
        //Get class para admin
        [HttpPost("obt_lesson")]
        public async Task<ActionResult<JSON_Object>> ObtainClass(Lessons_IDENT lesson_name)
        { //Function for obtaining  gear info.


            DataTable allLesson = DBData.GetClass(lesson_name.ID_Lessons);

            
            List<Lesson_Administration> lesson_List = new List<Lesson_Administration>();


            if (allLesson != null)
            {
                foreach (DataRow row in allLesson.Rows)
                {
                    Lesson_Administration LessonOBT = new Lesson_Administration();
                    LessonOBT.ID_Lessons = Convert.ToInt32(row["lesson_id"]);
                    LessonOBT.Quotas = Convert.ToInt32(row["quotas"]);
                    LessonOBT.Start_Date = row["start_date"].ToString();
                    LessonOBT.Final_Date = row["end_date"].ToString();
                    LessonOBT.Branch_Name = row["branch_name"].ToString();
                    LessonOBT.instructor_id = row["instructor_id"].ToString();
                    LessonOBT.service_id = row["service_id"].ToString();
                    LessonOBT.service_desc = row["service_description"].ToString();
                    LessonOBT.client_id = row["client_id"].ToString();

                    lesson_List.Add(LessonOBT);
                }
                


                JSON_Object json = new JSON_Object("ok", lesson_List);
                return Ok(json);
            }
            else { return BadRequest(); }

        }
        [HttpPost("add_client_to_lesson")] //para cliente
        public async Task<ActionResult<JSON_Object>> EnrollLesson(Client_Lessons client_lesson_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteEnrollLesson(client_lesson_data);
            Console.WriteLine(var);
            if (var)
            {
                json.status = "ok";
                return Ok(json);
            }
            else
            {

                return BadRequest(json);
            }


        }


    }
    
}
