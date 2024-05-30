﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/SellerDashboard.Master" AutoEventWireup="true" CodeBehind="SellerDashboard.aspx.cs" Inherits="ArtlyV1.Views.SellerDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <link rel="stylesheet" href="CSS/Dashboards.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-lg-4">
        <div class="row ml-3 mt-5 mr-3 justify-content-between">
            <div class="col-3">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title mb-9 fw-bold" style="font-size: 2rem; color:black">Sales</h5>
                        <div class="row align-items-center">
                            <div class="col-12">
                                <h4 class="fw-semibold mb-3"><%=sales%></h4>
                                <div class="d-flex align-items-center mb-3">
                                    <span
                                    class="me-1 rounded-circle bg-light-success round-20 d-flex align-items-center justify-content-center">
                                    <i class="ti ti-arrow-up-left text-success"></i>
                                    </span>
                                    <div class="d-flex align-items-center">
                                        <%if(salesToday > 0)
                                        {%>
                                          <i class="bi bi-arrow-up" style="color: green"></i>
                                          <p class="text-dark me-1 fs-3 mb-0" style="color:green !important;"><%=salesToday%></p>
                                        <%
                                        }
                                        else
                                        {%>
                                            <i class="bi bi-pause-fill"></i>
                                            <p class="text-dark me-1 fs-3 mb-0">0</p>
                                        <% 
                                        }%>
                                        <p class="fs-3 mb-0 m-sm-1">Today</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-3">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title mb-9 fw-bold" style="font-size: 2rem; color:black">Profit</h5>
                        <div class="row align-items-center">
                            <div class="col-12">
                                <h4 class="fw-semibold mb-3">Rp <%=String.Format("{0:N2}",revenue)%></h4>
                                <div class="d-flex align-items-center mb-3">
                                    <span
                                    class="me-1 rounded-circle bg-light-success round-20 d-flex align-items-center justify-content-center">
                                    <i class="ti ti-arrow-up-left text-success"></i>
                                    </span>
                                    <div class="d-flex align-items-center">
                                        <%if(revenueToday > 0)
                                        {%>
                                          <i class="bi bi-arrow-up" style="color: green"></i>
                                          <p class="text-dark me-1 fs-3 mb-0" style="color:green !important;">Rp <%=String.Format("{0:N2}",revenueToday)%></p>
                                        <%
                                        }
                                        else
                                        {%>
                                            <i class="bi bi-pause-fill"></i>
                                            <p class="text-dark me-1 fs-3 mb-0">0</p>
                                        <% 
                                        }%>
                                        <p class="fs-3 mb-0 m-sm-1">Today</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-3">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title mb-9 fw-bold" style="font-size: 2rem; color:black">Product</h5>
                        <div class="row align-items-center">
                            <div class="col-12">
                                <div class="d-flex align-items-center mb-3" style="font-size: 22px">
                                    <i class="bi bi-bag-fill"></i>
                                    <h4 class="fw-semibold align-items-center m-0 ml-2"><%=products%></h4>
                                </div>
                                <div class="d-flex align-items-center mb-3">
                                    <span
                                    class="me-1 rounded-circle bg-light-success round-20 d-flex align-items-center justify-content-center">
                                    <i class="ti ti-arrow-up-left text-success"></i>
                                    </span>
                                     <div class="d-flex align-items-center">
                                         <%if(productsToday > 0)
                                         {%>
                                           <i class="bi bi-arrow-up" style="color: green"></i>
                                           <p class="text-dark me-1 fs-3 mb-0" style="color:green !important;"><%=productsToday%></p>
                                         <%
                                         }
                                         else
                                         {%>
                                             <i class="bi bi-pause-fill"></i>
                                             <p class="text-dark me-1 fs-3 mb-0">0</p>
                                         <% 
                                         }%>
                                         <p class="fs-3 mb-0 m-sm-1">Today</p>
                                     </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="page-content page-container mt-5 pl-3" id="page-content">
            <div class="padding">
                <div class="d-flex align-items-center">
                    <div class="col-lg-8 grid-margin stretch-card">
                        <div class="card">
                            <div class="card-body-recent">
                                <h4 class="card-title">Recent Transaction</h4>
                                <p class="card-description">
                                    Transactions
                                </p>
                                <div class="table-responsive">
                                    <table class="table table-hover">
                                        <thead>
                                            <tr>
                                                <th>User</th>
                                                <th>Product</th>
                                                <th>Sale</th>
                                                <th>Status</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="RecentlyRPT">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Eval("Buyer") %></td>
                                                        <td><%# Eval("ProductName") %></td>
                                                        <td class="text-success"> Rp <%# String.Format("{0:N2}", Eval("Price"))%><i class="fa fa-arrow-up"></i></td>
                                                        <td><label class="badge badge-success">Completed</label></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
     <%--                                       <tr>
                                                <td>Hitesh Chauhan</td>
                                                <td>Engine</td>
                                                <td class="text-danger"> 18.76% <i class="fa fa-arrow-down"></i></td>
                                                <td><label class="badge badge-danger">Pending</label></td>
                                            </tr>
                                            <tr>
                                                <td>Samso Palto</td>
                                                <td>Brakes</td>
                                                <td class="text-danger"> 11.06% <i class="fa fa-arrow-down"></i></td>
                                                <td><label class="badge badge-warning">In progress</label></td>
                                            </tr>
                                            <tr>
                                                <td>Tiplis mang</td>
                                                <td>Window</td>
                                                <td class="text-danger"> 35.00% <i class="fa fa-arrow-down"></i></td>
                                                <td><label class="badge badge-info">Fixed</label></td>
                                            </tr>
                                            <tr>
                                                <td>Pter parker</td>
                                                <td>Head light</td>
                                                <td class="text-success"> 22.00% <i class="fa fa-arrow-up"></i></td>
                                                <td><label class="badge badge-success">Completed</label></td>
                                            </tr>
                                            <tr>
                                                <td>Ankit Dave</td>
                                                <td>Back light</td>
                                                <td class="text-success"> 28.05% <i class="fa fa-arrow-up"></i></td>
                                                <td><label class="badge badge-warning">In progress</label></td>
                                            </tr>--%>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
