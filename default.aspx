<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TPWebForm_equipo_5.VentanaProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" id="containerPrincipal">
        <div class="row">
            <div class="container text-center">
                <h1>Lista De Productos</h1>
            </div>

            <%if (listaMostrable)
                {%>
           
                 
                <div class="dropdown text-end" style="margin-right: 10px">
                    <asp:DropDownList ID="DdlOrden" runat="server" OnSelectedIndexChanged="DdlOrden_SelectedIndexChanged" AutoPostBack="true"
                        aria-label="Default select example" CssClass="btn  dropdown-toggle "
                        Style="background-color: white; font: bolder;">
                    </asp:DropDownList>
                </div>

                <div class="row row-cols-1 row-cols-md-3 g-1 d-flex justify-content-center p-3"  <%if (listaLecturaArticulos.Count() <= 3){ %> style="height: 700px" <%} %>>
                    <asp:Repeater runat="server" ID="repRepetidor">
                        <ItemTemplate>
                            <div class="col d-flex justify-content-center">
                                <div class="card" style="background-color: #274C77">
                                    <img src="<%#Eval("ImagenUrl")%>" class="card-img-top" alt="Image description" onerror="this.src='https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png'"
                                        style="max-width: 100%; height: 300px; object-fit: cover; background-color: whitesmoke;">
                                    <div class="card-body">
                                        <h4 class="card-title" style="color: #E7ECEF"><%#Eval("Nombre")%></h4>
                                        <h6 style="color: white">Precio: $<%#Eval("Precio")%> </h6>
                                    </div>
                                    <div class="card-footer">
                                        <asp:Button Text="Detalles" runat="server" CssClass="btn btn-light" ID="Btndetalle" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="Btndetalle_Click" />
                                        <asp:Button Text="Comprar ahora" CssClass="btn btn-primary" runat="server" ID="btnComprarAhora" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnComprarAhora_Click" />                                  
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                    </asp:Repeater>
            </div>
            <%}
                else
                {%>
            <div class="container text-center" style="height: 700px">
                <h2>No se encontraron productos con "<%=busqueda%>"</h2>
            </div>
            <%} %>
        </div>
    </div>
</asp:Content>
