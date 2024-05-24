<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="BecomeSeller.aspx.cs" Inherits="ArtlyV1.Views.BecomeSeller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <link rel="stylesheet" href="CSS/BecomSellerStyle.css">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper" style="min-height: 90vh; width: 100%;">
        <div class="static-slider1 py-4">
            <div class="container">
                <!-- Row  --> 
                <div class="row">
                    <!-- Column -->
                    <div class="col-md-7 align-self-center">
                        <h1 class="title">Mulai Petualangan Berjualan Anda di Artly Hari Ini! yang Pastinya  <span class="text-success-gradiant typewrite" data-period="2000" data-type='["Aman", "Cepat", "Support 24/7", "Komisi Rendah"]'></span></h1>
                        <input type="button" Class="mt-5 contentBtn" value="Read More" onClick="scrollToSection()"/>
                    </div>
                    <!-- Column -->
                    <div class="col-md-5 mt-4">
                        <img src="https://www.wrappixel.com/demos/ui-kit/wrapkit/assets/images/sliders/static-slider/slider1/img1.png" alt="wrapkit" class="img-fluid"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <section class="py-5 service-6" id="section-information">
        <div class="container">
            <!-- Row  -->
            <div class="row d-flex justify-content-center">
                <!-- Column -->
                <div class="col-md-4 wrap-service6-box">
                    <div class="card border-0 bg-danger-gradiant text-white mb-4">
                        <div class="card-body">
                            <h6 class="font-weight-medium text">Keamanan Terjamin</h6>
                            <p class="mt-3">Dengan sistem enkripsi terbaru dan pengawasan ketat, Anda dapat berjualan dengan tenang tanpa khawatir.</p>
                        </div>
                    </div>
                </div>
                <!-- Column -->
                <div class="col-md-4 wrap-service6-box">
                    <div class="card border-0 bg-danger-gradiant text-white mb-4">
                        <div class="card-body">
                            <h6 class="font-weight-medium text">Proses Pendaftaran Cepat dan Mudah</h6>
                            <p class="mt-3">Kami menawarkan proses pendaftaran yang sederhana dan cepat.</p>
                        </div>
                    </div>
                </div>
                <!-- Column -->
                <div class="col-md-4 wrap-service6-box">
                    <div class="card border-0 bg-danger-gradiant text-white mb-4">
                        <div class="card-body">
                            <h6 class="font-weight-medium text">Dukungan Pelanggan 24/7</h6>
                            <p class="mt-3">Tim dukungan kami siap membantu Anda kapan saja, setiap hari.</p>
                        </div>
                    </div>
                </div>
                <!-- Column -->
                <div class="col-md-4 wrap-service6-box">
                    <div class="card border-0 bg-danger-gradiant text-white mb-4">
                        <div class="card-body">
                            <h6 class="font-weight-medium text">Fee Terjangkau</h6>
                            <p class="mt-3">Nikmati struktur komisi yang kompetitif, dirancang untuk membantu Anda memaksimalkan profit tanpa beban biaya tinggi.</p>
                        </div>
                    </div>
                </div>
                <!-- Column -->
                <!-- Column -->
                <div class="col-md-4 wrap-service6-box">
                    <div class="card border-0 bg-danger-gradiant text-white mb-4">
                        <div class="card-body">
                            <h6 class="font-weight-medium text">Pembayaran yang Mudah</h6>
                            <p class="mt-3">Kami mendukung metode pembayaran melalu applikasi kami untuk memudahkan pembeli dalam melakukan transaksi, sehingga penjualan Anda dapat meningkat.</p>
                        </div>
                    </div>
                </div>
                <!-- Column -->
<%--                <div class="col-md-4 wrap-service6-box">
                    <div class="card border-0 bg-danger-gradiant text-white mb-4">
                        <div class="card-body">
                            <h6 class="font-weight-medium text">Powerful Techniques</h6>
                            <p class="mt-3">Lorem ipsum dolor sit amet, consecte tuam porttitor, nunc et fringilla.</p>
                        </div>
                    </div>
                </div>--%>
				<div class="col-md-12 mt-3 text-center">
                    <asp:Button CssClass="btn btn-outline-success btn-md" runat="server" Text="Join Now"></asp:Button>
                </div>
            </div>
        </div>
    </section>
    <script src="JS/BecomeSellerJs.js"></script>
</asp:Content>
