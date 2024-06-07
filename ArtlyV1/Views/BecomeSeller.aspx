<%@ Page Title="Artly | Become a Seller" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="BecomeSeller.aspx.cs" Inherits="ArtlyV1.Views.BecomeSeller" %>
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
                        <h1 class="title">Start selling your art at Artly! <span class="text-success-gradiant typewrite" data-period="2000" data-type='["Secure", "Fast", "24/7 Support", "Easy"]'></span></h1>
                        <input type="button" Class="mt-5 contentBtn" value="Read More" onClick="scrollToSection()"/>
                    </div>
                    <!-- Column -->
                    <div class="col-md-5 mt-4">
                        <img src="Images/SellerDashboard/BecomeSellerV2.png" alt="wrapkit" class="img-fluid"/>
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
                            <h6 class="font-weight-medium text">Security Guaranteed</h6>
                            <p class="mt-3">With the best encryption technology and the highest level of surveillance, you can sell your art without worrying.</p>
                        </div>
                    </div>
                </div>
                <!-- Column -->
                <div class="col-md-4 wrap-service6-box">
                    <div class="card border-0 bg-danger-gradiant text-white mb-4">
                        <div class="card-body">
                            <h6 class="font-weight-medium text">Fast and Easy Registration</h6>
                            <p class="mt-3">We offer a fast and easy registration process.</p>
                        </div>
                    </div>
                </div>
                <!-- Column -->
                <div class="col-md-4 wrap-service6-box">
                    <div class="card border-0 bg-danger-gradiant text-white mb-4">
                        <div class="card-body">
                            <h6 class="font-weight-medium text">24/7 Customer Support</h6>
                            <p class="mt-3">Our team is ready to support you at any time, every day.</p>
                        </div>
                    </div>
                </div>
                <!-- Column -->
                <div class="col-md-4 wrap-service6-box">
                    <div class="card border-0 bg-danger-gradiant text-white mb-4">
                        <div class="card-body">
                            <h6 class="font-weight-medium text">Low Fees</h6>
                            <p class="mt-3">Enjoy low commission fees, designed to help you maximize your profits.</p>
                        </div>
                    </div>
                </div>
                <!-- Column -->
                <!-- Column -->
                <div class="col-md-4 wrap-service6-box">
                    <div class="card border-0 bg-danger-gradiant text-white mb-4">
                        <div class="card-body">
                            <h6 class="font-weight-medium text">Easy Transactions</h6>
                            <p class="mt-3">We support our own payment method in order to ease the payment process.</p>
                        </div>
                    </div>
                </div>
				<div class="col-md-12 mt-3 text-center">
                    <button type="button" Class="btn btn-outline-success btn-md" data-toggle="modal" data-target="#modalAgreement" style="width:170px">Join Now</button>
                </div>
                  <div class='container'>
                    <div class="modal fade" id="modalAgreement" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
                        aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content p-4" id="modalContent" style="align-items: center;border-radius: 30px;">
                                <div class='top'>
                                    <img class="img-thumbnail"
                                        src="Images\ArtlyBrandImage.png" width="250px" height="250px" style="border:none; background:transparent" />
                                </div>
                                <div class="modal-title">
                                    <p style="font-weight:bold">User Agreement</p>
                                </div>
                                <div class="modal-header border-0 mb-2">
                                    <div class="modal-title" id="exampleModalLabel" style="text-align: center;">

                                        <div style="display:flex; justify-content:center">
                                            Welcome to <p  style="color:#FFC107; font-weight:bold; margin-left: 5px">Artly!</p>
                                        </div>

                                        This User Agreement ("Agreement") governs the terms and conditions under which sellers ("you" or "Seller") register and use the services provided by Artly ("we," "us," or "our"). By registering as a seller, you agree to be bound by the terms of this Agreement.

                                        1. Registration

                                        1.1 Eligibility: You must be at least 18 years old and capable of forming a legally binding contract to register as a seller.

                                        1.2 Accurate Information: You agree to provide accurate, complete, and current information during the registration process and to update such information as necessary.

                                        1.3 Verification: We reserve the right to verify your identity and the information provided. You authorize us to make inquiries, either directly or through third parties, to validate your information.

                                        2. Account Responsibilities

                                        2.1 Account Security: You are responsible for maintaining the confidentiality of your account credentials and for all activities that occur under your account.

                                        2.2 Prohibited Activities: You agree not to engage in any activities that are illegal, fraudulent, or that violate the rights of others, including intellectual property rights.

                                        3. Product Listings

                                        3.1 Accurate Descriptions: All products listed must be accurately described and comply with our listing policies. Misleading or false information is prohibited.

                                        3.2 Prohibited Items: You agree not to list any items that are illegal, prohibited by our policies, or that infringe on the rights of others.

                                        4. Fees and Payments

                                        4.1 Fees: You agree to pay the applicable fees for using our services as outlined in our fee schedule.

                                        4.2 Payment Processing: Payments for sales made through our platform will be processed according to our payment processing policies.

                                        5. Shipping and Fulfillment

                                        5.1 Shipping Responsibilities: You are responsible for shipping and delivering sold items to buyers promptly and securely.

                                        5.2 Fulfillment: You agree to adhere to our fulfillment policies and provide accurate tracking information for shipped items.

                                        6. Customer Service

                                        6.1 Communication: You agree to respond to buyer inquiries and resolve any disputes in a timely and professional manner.

                                        6.2 Returns and Refunds: You must honor your stated return and refund policy and comply with our return guidelines.

                                        7. Intellectual Property

                                        7.1 Ownership: You retain ownership of the content and materials you provide, but you grant us a non-exclusive, worldwide, royalty-free license to use, display, and distribute such content for the purposes of operating our platform.

                                        7.2 Infringement: You agree not to use our platform to sell items that infringe on the intellectual property rights of others.

                                        8. Termination

                                        8.1 Termination by Us: We reserve the right to suspend or terminate your account at any time for violations of this Agreement or our policies.

                                        8.2 Termination by You: You may terminate your account at any time by following the procedures outlined in your account settings.

                                        9. Limitation of Liability

                                        We shall not be liable for any indirect, incidental, or consequential damages arising out of or in connection with your use of our services.

                                        10. Governing Law

                                        This Agreement shall be governed by and construed in accordance with the laws of [Your Jurisdiction].

                                        11. Changes to the Agreement

                                        We reserve the right to modify this Agreement at any time. We will notify you of any changes, and your continued use of our services constitutes your acceptance of the revised Agreement.

                                        By registering as a seller on Artly, you acknowledge that you have read, understood, and agree to be bound by this User Agreement.
                                        <section id="end-agreement">
                                            Contact Information:

                                            For any questions or concerns regarding this Agreement, please contact us at Artly@gmail.com.
                                        </section>

                                        <div class="d-flex align-items-center mt-5">
                                            <label class="control control--checkbox mb-0">
                                                <span class="caption">Creating an account means you're okay with our <a style="color:#007bff">Terms and Conditions</a> and our <a style="color:#007bff">Privacy Policy</a>.</span>
                                                <input class="checkbx-agree" type="checkbox" id="check-agreement"/>
                                                <div class="control__indicator"></div>
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-body">
                                    <asp:Button runat="server" ID="createButton" CssClass="btn btn-primary" Text="Join" Enabled="false" OnClick="createButton_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                 </div>
            </div>
        </div>
    </section>
   <script>
        document.getElementById('check-agreement').addEventListener('change', function() {
            var createButton = document.getElementById('<%= createButton.ClientID %>');
            createButton.disabled = !this.checked;
        });
   </script>
    <script src="JS/BecomeSellerJs.js"></script>
</asp:Content>
