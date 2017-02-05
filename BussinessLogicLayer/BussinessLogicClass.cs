using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BussinessObjectsNamespace;
using DataAccessNamespace;


namespace BussinessLogicNamespace
{
    public class BussinessLogicClass
    {
        DataAccessClass dataAccessObject = new DataAccessClass();                   // Data-Access Object. So that it Bussiness Logic layer can interact with DataAccess layer.
        #region AdminLoginMethod
        public int AdminLogin(BussinessObjectsClass bussinessObject)
        {
            if (bussinessObject.UserName == "Admin" && bussinessObject.Password == "AdminPassword1.")  // Hardcoded Admin login Credentials. This is bad practice. I'll find a better way later. 
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion 
        #region AddBusMethod
        public int AddBus(BussinessObjectsClass bussinessObject)
        {
            int isQuerySuccessful = dataAccessObject.AddBus(bussinessObject);       // Addbus() method from DataAccess layer called and return value stored in isQuerySuccessful variable.
            return isQuerySuccessful;
        }
        #endregion
        #region ViewBusDetailsAdmin
        public DataSet ViewBus()
        {
            DataSet ds = dataAccessObject.ViewBusAdmin();                           // Store DataSet from ViewBusAdmin() method into another DatSet object. Remember this is because of 3-tier Architecture.
            return ds;                                                              // return DataSet.
        }
        #endregion
        #region DeleteBus
        public int DeleteBus(BussinessObjectsClass bussinessObject)
        {
            int isRecordDeleted = dataAccessObject.DeleteBus(bussinessObject);
            return isRecordDeleted;
        }
        #endregion
    }
}
