<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to emphasize records that were changed on the server side</title>
    <!-- Here I'm using links for jQuery stuff from Google CDN, it's can be easily changed on local-->
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
    <script type="text/javascript">
		 // <![CDATA[

        var previousVisibleRecords = new Array();
        var currentVisibleRecords = new Array();

        function InitializeCurrentState() {
            for (var i = 0; i < grid.GetVisibleRowsOnPage(); i++)
                currentVisibleRecords[grid.cpRowIndexes[i]] = grid.cpLocks[i];
        }

        function PreparePreviousState() {
            previousVisibleRecords = currentVisibleRecords.slice(0);
        }

        function CompareDifferences() {
            var changedRows = [];

            for (var i in currentVisibleRecords) {
                if (typeof (previousVisibleRecords[i]) == "undefined" ||
				   currentVisibleRecords[i] != previousVisibleRecords[i])
                    FlashRecord(i);
            }
        }

        function FlashRecord(index) {
            var records = $(".myGrid .dataRow:visible");
            $(records[index]).effect("highlight", {}, 3000);
        }

        function grid_Init(s, e) {
            InitializeCurrentState();
            scheduleGridUpdate(s);
        }

        function grid_BeginCallback(s, e) {
            PreparePreviousState();
            window.clearTimeout(timeout);
        }

        function grid_EndCallback(s, e) {
            InitializeCurrentState();

            CompareDifferences();
            scheduleGridUpdate(s);
        }

        /* timer */

        var timeout;

        function scheduleGridUpdate(grid) {
            window.clearTimeout(timeout);
            timeout = window.setTimeout(
				function () { if (!grid.IsEditing()) grid.Refresh(); },
				20000
			);
        }

		// ]]> 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="ods"
            KeyFieldName="Id" OnCustomJSProperties="grid_CustomJSProperties" CssClass="myGrid">
            <Columns>
                <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True"/>
                <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" VisibleIndex="1" Width="60px">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="SomeValue" VisibleIndex="2" Width="200px">
                    <EditFormSettings CaptionLocation="Top" ColumnSpan="2" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Lock" ReadOnly="True" VisibleIndex="3" Visible="false">
                </dx:GridViewDataTextColumn>
            </Columns>
            <ClientSideEvents Init="grid_Init" EndCallback="grid_EndCallback" BeginCallback="grid_BeginCallback" />
            <Styles>
                <Row CssClass="dataRow">
                </Row>
            </Styles>
            <SettingsLoadingPanel Mode="Disabled" />
        </dx:ASPxGridView>
    </div>
    <asp:ObjectDataSource ID="ods" runat="server" SelectMethod="GetDataSource" TypeName="BusinessObject"
        UpdateMethod="UpdateDataItem">
        <UpdateParameters>
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="SomeValue" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
