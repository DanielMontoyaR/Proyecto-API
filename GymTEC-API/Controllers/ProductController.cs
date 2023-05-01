using GymTEC_API.Entidades;
using GymTEC_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GymTEC_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductosController:ControllerBase
    {

        /// <summary>
        /// Method that returns a list with all the information
        /// of all products found within the database.
        /// </summary>
        /// <returns>A List with the Barcode, Name, Description, Price and branch_Name of all products.</returns>
        /// <remarks>This method queries a database to retrieve employees.</remarks>
        [HttpGet("all_product")]
        public async Task<ActionResult<JSON_Object>> AllProducts()
        { //Function for obtaining all Products.


            DataTable AllProduct = DBData.GetAllProducts();

            List<Product> Product_L = new List<Product>();



            foreach (DataRow row in AllProduct.Rows)
            {
                Product product = new Product();
                product.Barcode         = row["barcode"].ToString();
                product.Name            = row["name"].ToString();
                product.Description     = row["description"].ToString();
                product.price           = Convert.ToInt32(row["price"]);
                product.branch_Name     = row["branch_name"].ToString();

                Product_L.Add(product);
            }

            JSON_Object json = new JSON_Object("ok", Product_L);
            return Ok(json);


        }

        /// <summary>
        /// Method that returns a list with all the information 
        /// of a product given their Barcode.
        /// </summary>
        /// <param name="Product_Barcode">The Barcode of the product from which to retrieve all data.</param>
        /// <returns>A list of all employee information given the specified ID.</returns>
        /// <remarks>This method queries a database to retrieve employee.</remarks>
        [HttpPost("obt_product")]
        public async Task<ActionResult<JSON_Object>> ObtainProduct(Product_IDENT Product_Barcode)
        { //Function for obtaining  branch info.


            DataTable allProduct = DBData.GetProduct(Product_Barcode.Barcode);

            Product product = new Product();


            if (allProduct != null)
            {
                foreach (DataRow row in allProduct.Rows)
                {

                    product.Barcode         = row["barcode"].ToString();
                    product.Name            = row["name"].ToString();
                    product.Description     = row["description"].ToString();
                    product.price           = Convert.ToInt32(row["price"]);
                    product.branch_Name     = row["branch_name"].ToString();

                }

                JSON_Object json = new JSON_Object("ok", product);
                return Ok(json);
            }
            else { return BadRequest(); }

        }

        /// <summary>
        /// Method that adds a product.
        /// </summary>
        /// <param name="product_data">All product information to add to the database.</param>
        /// <returns>A confimation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpPost("add_product")]
        public async Task<ActionResult<JSON_Object>> AddProduct(Product product_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteAddProduct(product_data);
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

        /// <summary>
        /// Method that deletes a product given their Barcode.
        /// </summary>
        /// <param name="product_data">The Barcode of the product from which to delete all data.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpDelete("delete_product")]
        public async Task<ActionResult<JSON_Object>> DeleteProduct(Product_IDENT product_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.


            bool var = DBData.ExecuteDeleteProduct(product_data);
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


        /// <summary>
        /// Method that modifies a product given their information.
        /// </summary>
        /// <param name="product_data">The information of the product from which to modify their existing info.</param>
        /// <returns>A confirmation note or an error.</returns>
        /// <remarks>This method queries a database to delete employee.</remarks>
        [HttpPut("mod_product")]
        public async Task<ActionResult<JSON_Object>> ModProduct(Product product_data)
        {
            JSON_Object json = new JSON_Object("error", null); //Se inicializa con error y null para ver si hay algun error.

            bool var = DBData.ExecuteModProduct(product_data);
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
