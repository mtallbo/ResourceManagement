using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ITHS_DB_Lab3_Web
{
    public class SqlDatabase
    {
     
        private static string db_adress = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ITHS-DB-Labb3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        

        SqlConnection conn = new SqlConnection(db_adress);
        
        public SqlDatabase()
        {
            
        }

        //User queries
        public static IEnumerable<User> GetAllUsers()
        {
            List<UserDetails> userlist = new List<UserDetails>();
            using (SqlConnection conn = new SqlConnection(db_adress))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select US.Id, US.FirstName, US.LastName, US.RoleId, RO.[Name] from [User] US inner join [Role] RO on US.RoleId = RO.Id", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userlist.Add(new UserDetails()
                            {
                                Id = (int)reader["Id"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                RoleId = (int)reader["RoleId"],
                                Role = reader["Name"].ToString(),
                                FullName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString()
                        });
                        }
                    }
                    conn.Close();
                }
            }
            return userlist;
        }
        public static void AddUser(string FirstName, string LastName, int RoleId)
        {
            using (SqlConnection con = new SqlConnection(db_adress))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into [User] (FirstName, LastName, RoleId)" +
                    " values (@firstName, @lastName, @roleId)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@firstName", FirstName);
                cmd.Parameters.AddWithValue("@lastName", LastName);
                cmd.Parameters.AddWithValue("@roleId", RoleId);

                cmd.ExecuteNonQuery();
            }
        }
        public static void RemoveUser(int UserId)
        {
            using (SqlConnection con = new SqlConnection(db_adress))
            {
                SqlCommand cmd = new SqlCommand("delete [User] where Id = @Id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", UserId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static User FindUser(int Userid)
        {
           
            using (SqlConnection con = new SqlConnection(db_adress))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Id = @Id", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", Userid);

                SqlDataReader rdr = cmd.ExecuteReader();
                User usr = new User();
                while (rdr.Read())
                {
                    usr.Id = Convert.ToInt32(rdr["Id"]);
                    usr.FirstName = rdr["FirstName"].ToString();
                    usr.LastName = rdr["LastName"].ToString();
                    usr.RoleId = (int)rdr["RoleId"];
                    usr.FullName = rdr["FirstName"].ToString() + rdr["LastName"].ToString();
                }
                return usr;
            }
        }
        
        //Resource queries
        public static IEnumerable<Resource> GetAllResources() 
        {
            List<Resource> resourceList = new List<Resource>();
            using (SqlConnection conn = new SqlConnection(db_adress))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select * from [Resources]", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resourceList.Add(new Resource()
                            {
                                Id = (int)reader["Id"],
                                CategoryId = (int)reader["CategoryId"],
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                Cost = (int)reader["Cost"]
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return resourceList;
        }
        public static void AddResource(int CategoryId, string Name, string Description, int Cost)
        {
            using (SqlConnection con = new SqlConnection(db_adress))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("if not exists (select  1 from Resources where Resources.[Name] = @Name) begin insert [Resources] (CategoryId, [Name], [Description], Cost) values (@CategoryId, @Name, @Description, @Cost) end;", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Cost", Cost);

                cmd.ExecuteNonQuery();
            }
        }
        public static void RemoveResource(int ResourceId)
        {
            using (SqlConnection con = new SqlConnection(db_adress))
            {
                SqlCommand cmd = new SqlCommand("delete [Resources] where Id = @Id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", ResourceId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static Resource FindResource(int ResourecId)
        {
            using (SqlConnection con = new SqlConnection(db_adress))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Resources] WHERE Id = @Id", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", ResourecId);

                SqlDataReader rdr = cmd.ExecuteReader();
                Resource res = new Resource();
                while (rdr.Read())
                {
                    res.Id = Convert.ToInt32(rdr["Id"]);
                    res.CategoryId = (int)rdr["CategoryId"];
                    res.Name = rdr["Name"].ToString();
                    res.Description = rdr["Description"].ToString();
                    res.CategoryId = (int)rdr["Cost"];
                }
                return res;
            }
        }   

        //Resource entity queries
        public static IEnumerable<Resource_Entity> GetAllResourceEntity()
        {
            List<Resource_Entity> entitylist = new List<Resource_Entity>();
            using (SqlConnection conn = new SqlConnection(db_adress))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select * from [ResourceEntities]", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entitylist.Add(new Resource_Entity()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ResourceId = (int)reader["ResourceId"],
                                EntityId = (int)reader["EntityId"],
                                IdentificationNumber = reader["IdentificationNumber"].ToString(),
                                LostByLoanId = Convert.IsDBNull(reader["LostByLoanId"]) ? 0 : (int)reader["LostByLoanId"]
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return entitylist;
        }
        public static void AddResourceEntity(int ResourceId, int EntityId, string IdentificationNumber)
        {
            using (SqlConnection con = new SqlConnection(db_adress))
            {
                con.Open();

                //SqlCommand cmd = new SqlCommand("insert into [ResourceEntities] (ResourceId, EntityId, IdentificationNumber)" +
                //    " values (@resourceId, @entityId, @identificationNumber) where not exists (select * from [ResourceEntities] where entityId = @entityId and resourceid = @resourceid", con);

                SqlCommand cmd = new SqlCommand("if not exists (select  1 from ResourceEntities where EntityId = @entityId and ResourceId = @resourceid) " +
                    "begin insert[ResourceEntities] (ResourceId, EntityId, IdentificationNumber) values(@resourceId, @entityId, @identificationNumber)  end;", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@resourceId", ResourceId);
                cmd.Parameters.AddWithValue("@entityId", EntityId);
                cmd.Parameters.AddWithValue("@identificationNumber", IdentificationNumber);

                cmd.ExecuteNonQuery();
            }
        }
        public static void RemoveResourceEntity(int ResourceEntityId)
        {
            using (SqlConnection con = new SqlConnection(db_adress))
            {
                SqlCommand cmd = new SqlCommand("delete [ResourceEntities] where Id = @Id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", ResourceEntityId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static Resource_Entity FindResourceEntity(int ResourceEntityId)
        {

            using (SqlConnection con = new SqlConnection(db_adress))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [ResourceEntities] WHERE Id = @Id", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", ResourceEntityId);

                SqlDataReader rdr = cmd.ExecuteReader();
                Resource_Entity rce = new Resource_Entity();
                while (rdr.Read())
                {
                    rce.Id = Convert.ToInt32(rdr["Id"]);
                    rce.ResourceId = (int)rdr["ResourceId"];
                    rce.EntityId = (int)rdr["EntityId"];
                    rce.IdentificationNumber = rdr["IdentificationNumber"].ToString();
                    rce.LostByLoanId = Convert.IsDBNull(rdr["LostByLoanId"]) ? 0 : (int)rdr["LostByLoanId"];
                }
                return rce;
            }
        }

        //Loan queries
        public static IEnumerable<LoanDetails> GetAllLoans()
        {
            List<LoanDetails> loanlist = new List<LoanDetails>();

            using (SqlConnection conn = new SqlConnection(db_adress))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select * from LoanList", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            loanlist.Add(new LoanDetails()
                            {
                                Id = (int)reader["Id"],
                                BorrowerId = (int)reader["BorrowerId"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                StartDate = reader["StartDate"].ToString(),
                                EndDate = reader["EndDate"].ToString(),
                                ReturnDate = reader["ReturnDate"].ToString()
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return loanlist;
        }
        public static void AddLoanEntity(int loanerid, int borrowerid, int resourceentityid, string startdate, string enddate)
        {
            using (SqlConnection conn = new SqlConnection(db_adress))
            {
                using (SqlCommand cmd = new SqlCommand("spCreateLoan", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@loanerid", loanerid);
                    cmd.Parameters.AddWithValue("@borrowerid", borrowerid);
                    cmd.Parameters.AddWithValue("@resourceentityid", resourceentityid);
                    cmd.Parameters.AddWithValue("@startdate", startdate);
                    cmd.Parameters.AddWithValue("@enddate", enddate);

                    cmd.ExecuteReader();
                }
            }
        }
        public static void ReturnLoan(int loanId)
        {
            using (SqlConnection conn = new SqlConnection(db_adress))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlCommand cmd = new SqlCommand("spReturnLoan", conn)
                {
                    CommandType = CommandType.StoredProcedure

                })
                {
                    cmd.Parameters.AddWithValue("@loanId", loanId);
                    conn.Open();

                    cmd.ExecuteReader();
                }
            }
        }
        public static Loan GetLoan(int loanId)
        {
            using (SqlConnection con = new SqlConnection(db_adress))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Loans] WHERE Id = @Id", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", loanId);

                SqlDataReader rdr = cmd.ExecuteReader();
                Loan ln = new Loan();
                while (rdr.Read())
                {
                    ln.Id = Convert.ToInt32(rdr["Id"]);
                    ln.LoanerId = (int)rdr["LoanerId"];
                    ln.BorrowerId = (int)rdr["BorrowerId"];
                    ln.ResourceEntityId = (int)rdr["ResourceEntityId"];
                    //ln.LostByLoanId = Convert.IsDBNull(rdr["LostByLoanId"]) ? 0 : (int)rdr["LostByLoanId"];
                    ln.StartDate = rdr["StartDate"].ToString();
                    ln.EndDate = rdr["EndDate"].ToString();
                    ln.ReturnDate = rdr["ReturnDate"].ToString();
                }
                return ln;
            }
        }

        //Combos
        public static IEnumerable<Resource_Entity> GetAllResourceEntitiesByResource(int ResourceId)
        {
            List<Resource_Entity> entitylist = new List<Resource_Entity>();
            using (SqlConnection conn = new SqlConnection(db_adress))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [ResourceEntities] WHERE ResourceId = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", ResourceId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entitylist.Add(new Resource_Entity()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ResourceId = (int)reader["ResourceId"],
                                EntityId = (int)reader["EntityId"],
                                IdentificationNumber = reader["IdentificationNumber"].ToString(),
                                LostByLoanId = Convert.IsDBNull(reader["LostByLoanId"]) ? 0 : (int)reader["LostByLoanId"]
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return entitylist;
        }
        public static IEnumerable<Resource_EntityDetails> GetLostOrLoanedResourceEntities(int resourceId)
        {
            List<Resource_EntityDetails> entitylist = new List<Resource_EntityDetails>();

            using (SqlConnection conn = new SqlConnection(db_adress))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlCommand cmd = new SqlCommand("ResourceEntityAvailability", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.AddWithValue("@ResourceId", resourceId);
                    conn.Open();
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    Resource_EntityDetails rce = new Resource_EntityDetails();
                    while (reader.Read())
                    {
                        entitylist.Add(new Resource_EntityDetails()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            ResourceId = (int)reader["ResourceId"],
                            EntityId = (int)reader["EntityId"],
                            IdentificationNumber = reader["IdentificationNumber"].ToString(),
                            LostByLoanId = Convert.IsDBNull(reader["LostByLoanId"]) ? 0 : (int)reader["LostByLoanId"],
                            Loanable = reader["Availability"].ToString()
                        });
                    }
                }
            }
            return entitylist;
        }

        //Categories
        public static List<Categories> GetAllCategories()
        {
            List<Categories> categorieslist = new List<Categories>();

            using (SqlConnection conn = new SqlConnection(db_adress))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Categories", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categorieslist.Add(new Categories()
                            {
                                Id = (int)reader["Id"],
                                Category = reader["Category"].ToString(),
                                Identification = reader["Identification"].ToString()
                            });
                        }
                    }
                }
            }
            return categorieslist;
        }
        public static void AddCategory(string category, string identification)
        {
            using (SqlConnection conn = new SqlConnection(db_adress))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("if not exists (select  1 from Categories where Category = @category) begin insert[Categories]" +
                    "(Category, Identification) values(@category, @identification) end;", conn);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@identification", identification);

                cmd.ExecuteReader();
            }
        }

        //Roles roles
        public static List<Roles> GetAllRoles()
        {
            List<Roles> rolelist = new List<Roles>();
            using (SqlConnection conn = new SqlConnection(db_adress))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Role", conn)) 
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rolelist.Add(new Roles()
                            {
                                Id = (int)reader["id"],
                                Name = reader["Name"].ToString(),
                                PermissionLevel = (int)reader["PermissionLevel"]
                            });
                        }
                    }
                }
            }
            return rolelist;
        }
    }
}
