<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="TableDisplay.aspx.cs" Inherits="GarbageMaster.Pages.TableDisplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../wwwroot/css/home.css" />
    <link href="../wwwroot/bootstrap/animate.min.css" rel="stylesheet" />
    <script src="../wwwroot/js/jquery-3.6.3.js"></script>
    <script src="../wwwroot/bootstrap/jquery.dataTables.js"></script>
    <link href="../wwwroot/bootstrap/jquery.dataTables.css" rel="stylesheet" />
    <link href="../wwwroot/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="../wwwroot/bootstrap/bootstrap-icons.css" rel="stylesheet" />
    <link href="../wwwroot/css/Wastedata.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="hero">
    <div id="heroCarousel" data-bs-interval="5000" class="carousel slide carousel-fade" data-bs-ride="carousel">

      <ol class="carousel-indicators" id="hero-carousel-indicators"></ol>

      <div class="carousel-inner" role="listbox">
        <div class="carousel-item active" style="background-image: url(../wwwroot/images/data-analyst.jpg)">
          <div class="carousel-container">
            <div class="container">
              <h2 class="animate__animated animate__fadeInDown">Waste Data</h2>
              <p class="animate__animated animate__fadeInUp">Here is the waste data you have provided till date, Due to confidentiality we maintain, we cannot share the data of your neighbours. Though you can get the summarization of your whole ward that includes how much waste your ward have in average.</p>
              <a href="#tablethis" class="btn-get-started animate__animated animate__fadeInUp scrollto">View Data</a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
    <div>
        <h2 class="mt-4">Waste Data</h2>
    </div>
    <div id="tablethis">
    <asp:GridView ID="GridView1" CssClass="table display compact p-5" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="UsernameWH" HeaderText="Username" SortExpression="UsernameWH"></asp:BoundField>
            <asp:BoundField DataField="Waste_Data_History" HeaderText="Waste Data(in Plastic)" SortExpression="Waste_Data_History"></asp:BoundField>
            <asp:BoundField DataField="WardNoWH" HeaderText="Ward Number" SortExpression="WardNoWH"></asp:BoundField>
        </Columns>
    </asp:GridView>
    </div>
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:GarbageMasterConnectionString %>" SelectCommand="SELECT [UsernameWH], [Waste_Data_History], [WardNoWH] FROM [TblWasteHistory]"></asp:SqlDataSource>
</asp:Content>
