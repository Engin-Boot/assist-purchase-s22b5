using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Net;
using DataModel;

namespace DataAccessLayer
{
    public class ProjectManagementSqLite: IProductManagement
    {
        private readonly SQLiteConnection _con;
        public ProjectManagementSqLite()
        {
            var cs = $@"URI=file:{Directory.GetCurrentDirectory()}\AssistPurchase.db";

            _con = new SQLiteConnection(cs);
            _con.Open();

            using var cmd = new SQLiteCommand(_con) { CommandText = "DROP TABLE IF EXISTS MonitoringProducts" };

            cmd.ExecuteNonQuery();
            cmd.CommandText = "DROP TABLE IF EXISTS MonitoringMeasurements";
            cmd.ExecuteNonQuery();

            //Create Table MonitoringProducts
            cmd.CommandText = @"CREATE TABLE MonitoringProducts(
                                id INTEGER PRIMARY KEY,
                                productName TEXT NOT NULL UNIQUE, 
                                productSeries TEXT, 
                                productModel TEXT,
                                screenSize REAL, 
                                productWeight REAL, 
                                portable BOOLEAN, 
                                monitorResolution TEXT)";
            cmd.ExecuteNonQuery();

            //Create Table MonitoringMeasurements
            cmd.CommandText = @"CREATE TABLE MonitoringMeasurements(
                                productName TEXT NOT NULL, 
                                measurements TEXT,
                                FOREIGN KEY(productName) REFERENCES MonitoringProducts(productName) ON DELETE CASCADE
                                )";
            cmd.ExecuteNonQuery();


            // Insert Data 1
            cmd.CommandText = "INSERT INTO MonitoringProducts(productName, productSeries, productModel, screenSize, productWeight, portable, monitorResolution) VALUES('IntelliVue X3','Intellivue','X3',7.1,1300,true,'1024*720')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO MonitoringMeasurements( productName, measurements) VALUES('IntelliVue X3','SPO2')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO MonitoringMeasurements( productName, measurements) VALUES('IntelliVue X3','ECG')";
            cmd.ExecuteNonQuery();



            // Insert Data 2
            cmd.CommandText = "INSERT INTO MonitoringProducts(productName, productSeries, productModel, screenSize, productWeight, portable, monitorResolution) VALUES('IntelliVue MX40','Intellivue','MX40',12,1400,false,'1024*920')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO MonitoringMeasurements( productName, measurements) VALUES('IntelliVue MX40','SPO2')";
            cmd.ExecuteNonQuery();
            _con.Close();
        }

        public HttpStatusCode AddProduct(ProductDataModel product)
        {
            try
            {
                _con.Open();
                if (string.IsNullOrEmpty(product.ProductName))
                {
                    throw new Exception();
                }

                var cmd = new SQLiteCommand(_con)
                {
                    CommandText =
                        @"INSERT INTO MonitoringProducts(productName, productSeries, productModel, screenSize, productWeight, portable, monitorResolution) 
                                    VALUES
                                    (@productName, @productSeries, @productModel, @screenSize, @productWeight, @portable, @monitorResolution)"
                };

                cmd.Parameters.AddWithValue("@productName", product.ProductName);
                cmd.Parameters.AddWithValue("@productSeries", product.ProductSeries);
                cmd.Parameters.AddWithValue("@productModel", product.ProductModel);
                cmd.Parameters.AddWithValue("@screenSize", product.ScreenSize);
                cmd.Parameters.AddWithValue("@productWeight", product.Weight);
                cmd.Parameters.AddWithValue("@portable", product.Portable);
                cmd.Parameters.AddWithValue("@monitorResolution", product.MonitorResolution);
                cmd.Prepare();

                cmd.ExecuteNonQuery();

                foreach (var newMeasurement in product.Measurement)
                {
                    cmd.CommandText = @"INSERT INTO MonitoringMeasurements( productName, measurements) 
                                        VALUES
                                        (@productName, @measurements)";
                    cmd.Parameters.AddWithValue("@productName", product.ProductName);
                    cmd.Parameters.AddWithValue("@measurements", newMeasurement);
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();

                }

            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
            finally
            {
                _con.Close();
            }

            return HttpStatusCode.OK;
        }

        public HttpStatusCode RemoveProduct(ProductDataModel product)
        {
            try
            {
                _con.Open();
                var cmd = new SQLiteCommand(_con)
                {
                    CommandText = $@"DELETE FROM MonitoringProducts WHERE id='{product.Id}'"
                };
                var rows=cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    return HttpStatusCode.BadRequest;
                }

                cmd.CommandText = $@"DELETE FROM MonitoringMeasurements WHERE productName='{product.ProductName}'";
                cmd.ExecuteNonQuery();


            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
            finally
            {
                _con.Close();
            }

            return HttpStatusCode.OK;
        }


        public IEnumerable<ProductDataModel> GetAllProducts()
        {
            _con.Open();
            var list = new List<ProductDataModel>();


            var stm = @"SELECT p.id, p.productName, productSeries, productModel, screenSize, productWeight, portable, monitorResolution 
                        FROM MonitoringProducts p";
            using var cmd1 = new SQLiteCommand(stm, _con);
            using var rdr = cmd1.ExecuteReader();




            while (rdr.Read())
            {
                var stm2 = @"SELECT productName, measurements 
                         FROM MonitoringMeasurements";
                using var cmd2 = new SQLiteCommand(stm2, _con);
                using var rdr2 = cmd2.ExecuteReader();

                var measurements = new List<string>();
                var prodName = rdr.GetString(1);
                //Console.WriteLine(prodName);
                //Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetString(2)} {rdr.GetString(3)} {rdr.GetDouble(4)} {rdr.GetDouble(5)} {rdr.GetBoolean(6)} {rdr.GetString(7)}");
                while (rdr2.Read())
                {
                    if (rdr2.GetString(0) == prodName)
                    {
                        measurements.Add(rdr2.GetString(1));
                    }
                }
                list.Add(new ProductDataModel()
                {
                    Id = rdr.GetInt32(0),
                    ProductName = rdr.GetString(1),
                    ProductSeries = rdr.GetString(2),
                    ProductModel = rdr.GetString(3),
                    ScreenSize = rdr.GetDouble(4),
                    Weight = rdr.GetDouble(5),
                    Portable = rdr.GetBoolean(6),
                    MonitorResolution = rdr.GetString(7),
                    Measurement = measurements
                });
            }
            _con.Close();
            return list;
        }

        public HttpStatusCode UpdateProduct(ProductDataModel product)
        {
            
            var removeStatusCode=RemoveProduct(product); 
            var addStatusCode=AddProduct(product);
            if(removeStatusCode==HttpStatusCode.OK && addStatusCode==HttpStatusCode.OK)
                return HttpStatusCode.OK;

            return HttpStatusCode.InternalServerError;
        }
    }
}
