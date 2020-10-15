using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Net;
using DataModel;

namespace DataAccessLayer
{
    public class ProductManagementSqLite: IProductManagement
    {
        
        /*public ProductManagementSqLite()
        {
            *//*var cs = $@"URI=file:{Directory.GetCurrentDirectory()}\AssistPurchase.db";

            _con = new SQLiteConnection(cs);*//*
        }*/

        public HttpStatusCode AddProduct(ProductDataModel product)  
        {
            var con = GetConnection();
            try
            {
                
                con.Open();
                if (string.IsNullOrEmpty(product.ProductName))
                {
                    return HttpStatusCode.BadRequest;
                }

                var cmd = new SQLiteCommand(con)
                {
                    CommandText =
                        @"INSERT INTO MonitoringProducts(id, productName, productSeries, productModel, screenSize, productWeight, portable, monitorResolution) 
                                    VALUES
                                    (@id, @productName, @productSeries, @productModel, @screenSize, @productWeight, @portable, @monitorResolution)"
                };

                cmd.Parameters.AddWithValue("@id", product.Id);
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
                con.Close();
            }

            return HttpStatusCode.OK;
        }

        public HttpStatusCode RemoveProduct(ProductDataModel product)
        {
            var con = GetConnection();
            try
            {

                con.Open();
                var cmd = new SQLiteCommand(con)
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
                con.Close();
            }

            return HttpStatusCode.OK;
        }


        public IEnumerable<ProductDataModel> GetAllProducts()
        {
            var con = GetConnection();
                con.Open();
            var list = new List<ProductDataModel>();


            var stm = @"SELECT p.id, p.productName, productSeries, productModel, screenSize, productWeight, portable, monitorResolution 
                        FROM MonitoringProducts p";
            using var cmd1 = new SQLiteCommand(stm, con);
            using var rdr = cmd1.ExecuteReader();




            while (rdr.Read())
            {
                var stm2 = @"SELECT productName, measurements 
                         FROM MonitoringMeasurements";
                using var cmd2 = new SQLiteCommand(stm2, con);
                using var rdr2 = cmd2.ExecuteReader();

                var measurements = new List<string>();
                var prodName = rdr.GetString(1);
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
            con.Close();
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

        private static SQLiteConnection GetConnection()
        {
            var cs = $@"URI=file:{Directory.GetCurrentDirectory()}\AssistPurchase.db";
            var con = new SQLiteConnection(cs);
            return con;
        }
    }
}
