<%@ Page Title="" Language="C#" MasterPageFile="~/StocksMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RJStocks.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-4">
                <asp:TextBox ID="txtSymbol" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-8 col-md-8 col-sm-8">
                <asp:Button ID="bntSubmit" Text="Submit" CssClass="btn btn-primary" runat="server" OnClick="bntSubmit_Click" />
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="panel panel-default">
            <div class="table-responsive">
                <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
                <asp:Timer ID="ctlTimer" Interval="120000" OnTick="TimerInterval" runat="server"></asp:Timer>
                <asp:UpdatePanel ID="up1" UpdateMode="Conditional" runat="server">
           
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ctlTimer" EventName="Tick" />
                    </Triggers>

                    <ContentTemplate>
                        <asp:GridView ID="GridView1" CssClass="table table-responsive" AutoGenerateColumns="true" GridLines="None" AlternatingRowStyle-CssClass="alert-info" runat="server">
                        </asp:GridView>
                        <asp:Label id="lblUpdated" CssClass="alert-warning" Visible="true" runat="server"></asp:Label> 
                    </ContentTemplate>

                </asp:UpdatePanel>

            </div>
        </div>
    </div>
</asp:Content>
