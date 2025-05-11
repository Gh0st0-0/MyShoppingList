using System.Data;

namespace ShoppingList.ServiceUtilities
{
    public class ConvertObjectToDataSet
    {
        /// <summary>
        /// Convert ant List of object to Dataset
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="tableName"></param>
        /// <returns>DataSet</returns>
        public DataSet ConvertListToDataSet<T>(List<T> obj, string tableName = "HeaderData")
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable(tableName);

            if (obj != null && obj.Count > 0)
            {
                var property = obj[0].GetType().GetProperties();
                foreach (var prop in property)
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }

                foreach (var item in obj)
                {
                    DataRow newRow = dt.NewRow();
                    for (int i = 0; i < property.Length; i++)
                    {
                        newRow[property[i].Name] = property[i].GetValue(item, null) ?? DBNull.Value;
                    }
                    dt.Rows.Add(newRow);
                }
            }
            ds.Tables.Add(dt);
            return ds;
        }
    }
}
