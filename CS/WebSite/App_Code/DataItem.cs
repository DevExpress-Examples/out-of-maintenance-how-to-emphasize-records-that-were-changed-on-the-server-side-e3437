using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class DataItem {
    public DataItem(Int32 id, String someValue) {
        this.id = id;
        this.someValue = someValue;
        this._lock = 0;
    }

    private Int32 id;
    public Int32 Id {
        get {
            return id;
        }
    }

    private String someValue;
    public String SomeValue {
        get {
            return someValue;
        }
        set {
            UpdateItem(value);
        }
    }

    private Int32 _lock;
    public Int32 Lock {
        get {
            return _lock;
        }
    }

    public void UpdateItem(String value) {
        this.someValue = value;
        this._lock++;
    }
}