using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BusinessObject {
    private String SessionKey = "Some key";

    public List<DataItem> GetDataSource() {
        if (HttpContext.Current.Session[SessionKey] == null) {
            List<DataItem> items = new List<DataItem>();

            items.Add(new DataItem(0, "Value"));
            items.Add(new DataItem(1, "Random value"));
            items.Add(new DataItem(2, "Some value"));
            items.Add(new DataItem(3, "Just a value"));
            items.Add(new DataItem(4, "Unknown value"));
            items.Add(new DataItem(5, "Public value"));
            items.Add(new DataItem(6, "Secret value"));

            HttpContext.Current.Session[SessionKey] = items;
        }

        return (List<DataItem>)HttpContext.Current.Session[SessionKey];
    }

    public void UpdateDataItem(Int32 Id, String SomeValue) {
        List<DataItem> items = GetDataSource();
        
        DataItem item = items.Find(i => i.Id == Id);
        item.UpdateItem(SomeValue);
    }
}