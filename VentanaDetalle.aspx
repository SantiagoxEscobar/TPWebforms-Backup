<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="VentanaDetalle.aspx.cs" Inherits="TPWebForm_equipo_5.VentanaDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="modal fade" id="btnAvisoCompra" tabindex="k-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Consulta enviada con exito</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    Su consulta se enviará a nuestro equipo de ventas, quienes se pondrán en contacto con usted en el menor tiempo posible.
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="container" id="containerDetalle">
        <div class="row">
            <div class="col-md-5">
                <div id="carouselExample" class="carousel slide">
                    <div class="carousel-inner">
                        <%if (listaImagenes != null)
                            {%>
                        <%if (listaImagenes.Count() > 1)
                            { %>
                        <div class="carousel-item active">
                            <img src="<%= listaImagenes[0].ImagenUrl%>" class="d-block w-100" alt="Imagen" onerror="this.src='https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png'"
                                style="max-width: 100%; height: 500px; object-fit: cover; background-color: white" />
                        </div>
                        <% foreach (var item in listaImagenes.Skip(1))
                            { %>
                        <div class="carousel-item">
                            <img src="<%:item.ImagenUrl%>" class="d-block w-100" alt="Imagen" onerror="this.src='https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png'"
                                style="max-width: 100%; height: 500px; object-fit: cover; background-color: white" />
                        </div>
                        <% }
                            }
                            else
                            { %>
                        <div class="carousel-item active">
                            <img src="<%= listaImagenes[0].ImagenUrl%>" class="d-block w-100" alt="Imagen" onerror="this.src='https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png'"
                                style="max-width: 100%; height: 500px; object-fit: cover; background-color: white" />
                        </div>
                        <%  }
                        %>
                    </div>
                    <%if (listaImagenes.Count() > 1)
                        {%>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                    <%} %>
                    <%} %>
                </div>
            </div>
            <div class="col-md-7">
                <div class="container">
                    <div>
                        <asp:Label ID="lblNombreArticulo" runat="server" Text="Articulo Detalle SuperMax" CssClass="h1" />
                    </div>
                    <div>
                        <asp:Label ID="lblPrecio" runat="server" Text="Precio Detalle" CssClass="h3" />
                    </div>
                </div>
                <div class="container">
                    <div>
                        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción Detalle" CssClass="p" />
                    </div>
                    <div style="display: flex; flex-direction: row; align-items: center;">
                        <h4 style="margin-right: 10px;">Categoria: </h4>
                        <asp:Label ID="lblCategoria" runat="server" Text="Categoría Detalle" CssClass="h5" />
                    </div>
                    <div style="display: flex; flex-direction: row; align-items: center;">
                        <h4 style="margin-right: 10px;">Marca: </h4>
                        <asp:Label ID="lblMarca" runat="server" Text="Marca Detalle" CssClass="h5" />
                    </div>
                </div>
                <div class="container text-end">
                    <div class="row">
                        <div>
                            <asp:Button Text="Comprar ahora" CssClass="btn btn-primary" runat="server" ID="btnComprarAhora" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnComprarAhora_Click" />
                        </div>
                        <div>
                            <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al carrito" CssClass="btn btn-primary" OnClick="btnAgregarCarrito_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container" id="containerFormulario">
        <div class="container text-center">
            <h3>¿Requiere más información?</h3>
            <p>Complete el siguiente formulario y nos pondremos en contacto con usted en el menor tiempo posible.</p>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <div class="mb-3">
                        <h5>Formulario de contacto</h5>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre" />
                    </div>
                    <div class="mb-3">
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" placeholder="Email" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="mb-3">
                        <h5>Consulta</h5>
                        <asp:TextBox ID="txtConsulta" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Escriba su consulta aquí" Rows="3" />
                        <div class="container text-end">
                            <button type="button" class="btn btn-success w-75" data-bs-toggle="modal" data-bs-target="#btnAvisoCompra">
                                Enviar Consulta
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container" id="containerPoliticas">
        <div class="container text-center">
            <h5>Política de Devoluciones y Garantías</h5>
            <p style="text-transform: uppercase">
                En el nombre de la tienda, nos comprometemos a ofrecer productos de alta calidad y a garantizar la satisfacción
                de nuestros clientes. En caso de que no estés completamente satisfecho con tu compra, te ofrecemos una política de devoluciones
                y garantías que te permite devolver o cambiar el producto de acuerdo a las condiciones establecidas en este documento.
            </p>
        </div>
    </div>

</asp:Content>
