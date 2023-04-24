﻿using GymTEC_API.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace GymTEC_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class BranchController:ControllerBase
    {
        [HttpGet("all_branches")]
        public async Task<ActionResult<JSON_Object>> AllBranches() { //Function for obtaining all branch names.
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            List<Branch> branch_L = new List<Branch>();

            branch_L.Add(new Branch { Name = "Cartago"});
            branch_L.Add(new Branch { Name = "Heredia" });
            branch_L.Add(new Branch { Name = "Chepe" });
            branch_L.Add(new Branch { Name = "Alajuela" });
            branch_L.Add(new Branch { Name = "Puntarenas" });
            branch_L.Add(new Branch { Name = "Taras" });

            json.status = "ok";
            //json.result = branch_L.;
            List<String> listNames = new List<String>();

            foreach (var Branchnames in branch_L) {
                listNames.Add(Branchnames.Name); ;
            }

            json.result = listNames;
            return Ok(json);
        }

        [HttpGet("obt_branch")]
        public async Task<ActionResult<JSON_Object>> ObtainBranch([FromQuery] Branch branch_name)
        { //Function for obtaining  branch info.
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            Branch branch_info = new Branch();

            branch_info.Name = "Cartago";
            branch_info.Canton = "Central";
            branch_info.District = "San Nicolás";
            branch_info.opening_Date = "Monday to Sunday";
            branch_info.schedule_Attention = "7:00 / 19:00";

            if(branch_name.Name == branch_info.Name)
            {
                json.status = "ok";
                json.result = branch_info;
                return Ok(json);
            }
            return json;

        }

        [HttpPost("add_branch")]
        public async Task<ActionResult<JSON_Object>> AddBranch([FromQuery] Branch branch_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            Branch branch_L = new Branch();

            Spa spa_Link = new Spa(); 
            Shop shop_Link = new Shop();   
            BranchPhone phone_Link = new BranchPhone();
            Lesson lesson_Link = new Lesson();
            Inventory inventory_Link = new Inventory();
            Employee employee_Link = new Employee();



            /*
            branch_L.Add(new Branch { Name = "Cartago" });
            branch_L.Add(new Branch { Name = "Heredia" });
            branch_L.Add(new Branch { Name = "Chepe" });
            branch_L.Add(new Branch { Name = "Alajuela" });
            branch_L.Add(new Branch { Name = "Puntarenas" });
            branch_L.Add(new Branch { Name = "Taras" });*/

            if (!branch_data.Name.Trim().Equals(string.Empty)) {
                branch_L = branch_data;

                spa_Link.Branch_Name        = branch_data.Name;
                shop_Link.Branch_Name       = branch_data.Name;
                phone_Link.Branch_Name      = branch_data.Name;
                lesson_Link.Branch_Name     = branch_data.Name;
                employee_Link.Branch_Name   = branch_data.Name;
                inventory_Link.Branch_Name  = branch_data.Name;

                json.status = "Ok";
                json.result = branch_L;
                json.result = spa_Link;
                return Ok(json);
            }


            return json;
        }
    }
}