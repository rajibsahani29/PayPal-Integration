<%@ Page Language="VB" AutoEventWireup="false" CodeFile="purchase_credits.aspx.vb" Inherits="purchase_credits"  MasterPageFile="main.master" %>  
  
  <asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        
      	<!--// KODE BENNER1 START //-->
				<div class="kode_benner1 bamnner2">
					<div class="kode_benner1_text"> 
					</div>
					<div class="kode_benner1_cols">
						<div class="container kf_container">
							<ul class="breadcrumb">
							  <li><a   href="#">Home</a></li>
							  <li class="active">Purchase Credits</li>
							</ul>
						</div>
					</div>
				</div>
				<!--// KODE BENNER1 END //-->
        <br /><br />
				Enter Voucher Code
                        <br /><br />
                        <asp:TextBox ID="TB_Voucher_Code" runat="server"></asp:TextBox>
						  <br /><br />

                        <asp:Button ID="BUT_Voucher_Code" runat="server" Text="Apply Voucher Code" />
                        <br /><br />
                        <asp:Label ID="LABEL_Voucher_Code" runat="server" Text=""></asp:Label>

                        <br /><br />

				<!--// KODE TICKET SINGLE WRAPER START //-->
				<div class="kode_ticket_sigle_wraper">
					<div class="container">
					

						<div class="kode_ticket_standerd_detail clsUserCredit">
							<div class="kode_standerd_date">
								<h6><i class="fa fa-credit-card"></i>Select from our fantastic credit packages</h6>
								<h6 class="full-right"><i class="fa fa-paypal"></i>Secure payments via PayPal</h6>
							</div>
							<ul>

								<li>
									<div class="kode_satnderd_text">
										<a href="#"><i class="fa fa-ticket"></i></a>
										<div class="kode_standerd_title">
											<h4></h4>
											<p>Save money by buying 10/20/etc</p>
										</div>
									</div>
									<span class="kode_standerd_doller">£<asp:Label ID="LABEL_COST" runat="server" Text="Label"></asp:Label> / Credits  &nbsp&nbsp&nbsp   </span>
									<div class="kode_standerd_select">
										
                                        
                                        <asp:TextBox ID="TB_No_Of_Credits" runat="server"></asp:TextBox>              
                                        
                                        
                                        <!-- Spinner -->
										<h2 class="demoHeaders">Total:</h2>
                                        <asp:HiddenField ID="hdnTotalAmount" runat="server" Value="" />
										<asp:TextBox ID="TB_Total_Amount" runat="server" ReadOnly="true"></asp:TextBox> 
									</div>
									 <asp:Button ID="BUT_Buy" class="clsBtnBuy" runat="server" Text="Buy Now" />
                                     <asp:Button ID="BUT_Buy_Paydoo" class="clsBtnBuy" runat="server" Text="Buy Now Paydoo" />
                                     <asp:Button ID="BUT_Buy_Paytogather" class="clsBtnBuy" runat="server" Text="Buy Now Paytogather" />
								</li>
                                <asp:Label ID="LABEL_Error_Msg" runat="server" Text=""></asp:Label>

                               


							</ul>
                             <br /><br />
                             <asp:Label ID="LABEL_Voucher_Msg" runat="server" Text=""></asp:Label>
						</div>
					</div>
				</div>
				<!--// KODE TICKET SINGLE WRAPER END //-->
				
<script type="text/javascript">

    $("#<%= TB_No_Of_Credits.ClientID %>").blur(function () {

        if ($("#<%= TB_No_Of_Credits.ClientID %>").val() == "" || parseInt($("#<%= TB_No_Of_Credits.ClientID %>").val()) <= 0) {
            $("#<%= LABEL_Error_Msg.ClientID %>").html("Please enter credit.");
            $("#<%= TB_Total_Amount.ClientID %>").val(0);
            $("#<%= hdnTotalAmount.ClientID %>").val(0);
            return false;
        }
        
        if ($("#<%= TB_No_Of_Credits.ClientID %>").val() != "") {
    
            if (isNaN($("#<%= TB_No_Of_Credits.ClientID %>").val())) {
                $("#<%= LABEL_Error_Msg.ClientID %>").html("Please place a numeric value.");
                $("#<%= TB_Total_Amount.ClientID %>").val(0);
                $("#<%= hdnTotalAmount.ClientID %>").val(0);
                return false;
            }
            else {
                //alert("Hello");
                var NoOfCredits = $("#<%= TB_No_Of_Credits.ClientID %>").val();
                //alert(NoOfCredits);
                if (NoOfCredits != "" && NoOfCredits > 0) {

                    var doaction = "getGameCostsByCompanyIdAndCredx";

                    var ReturnCreditAmount = 0

                    $(document).ajaxStart(function () {
                        $(".clsUserCredit").addClass("aiLoading");
                    });
                    $(document).ajaxComplete(function () {
                        $(".clsUserCredit").removeClass("aiLoading");
                        $(document).unbind("ajaxStart ajaxStop");
                    });
                    $.post('GetAjaxData.aspx', { DoAction: doaction, NoOfCredits: NoOfCredits }, function (responseText) {
                        //alert(responseText.toString());
                        if (responseText.toString() != "") {
                            //var objExtraDetail = JSON.parse(responseText)
                            //alert(objExtraDetail.StaffId);
                            ReturnCreditAmount = responseText.toString();
                        }
                    }).done(function () {
                        if (parseFloat(ReturnCreditAmount) > 0) {
                            //alert(ReturnCreditAmount);
                            $("#<%= LABEL_Error_Msg.ClientID %>").html("");
                            $("#<%= TB_Total_Amount.ClientID %>").val(parseFloat(ReturnCreditAmount).toFixed(2));
                            $("#<%= hdnTotalAmount.ClientID %>").val(ReturnCreditAmount.toString());
                        }
                        else {
                            $("#<%= LABEL_Error_Msg.ClientID %>").html("");
                            var CreditAmount = parseFloat($("#<%= LABEL_COST.ClientID %>").html());
                            var NoOfCredit = parseFloat($("#<%= TB_No_Of_Credits.ClientID %>").val());
                            $("#<%= TB_Total_Amount.ClientID %>").val(parseFloat(CreditAmount * NoOfCredit).toFixed(2));
                            $("#<%= hdnTotalAmount.ClientID %>").val((CreditAmount * NoOfCredit));
                        }
                    }); ;
                }
            }
        }
    });

    $(".clsBtnBuy").click(function () {
        
        if ($("#<%= TB_No_Of_Credits.ClientID %>").val() == "" || parseInt($("#<%= TB_No_Of_Credits.ClientID %>").val()) <= 0) {
            $("#<%= LABEL_Error_Msg.ClientID %>").html("Please enter credit.");
            $("#<%= TB_Total_Amount.ClientID %>").val(0);
            $("#<%= hdnTotalAmount.ClientID %>").val(0);
            return false;
        }

        if (isNaN($("#<%= TB_No_Of_Credits.ClientID %>").val())) {
            $("#<%= LABEL_Error_Msg.ClientID %>").html("Please place a numeric value.");
            $("#<%= TB_Total_Amount.ClientID %>").val(0);
            $("#<%= hdnTotalAmount.ClientID %>").val(0);
            return false;
        }
    });

    function CheckAndUpdateVouchersCodeId(clientid, voucherid) {
        //alert(clientid);
        //alert(voucherid);

        if (clientid > 0 && voucherid > 0) {
            if (confirm("New code will replace your current voucher code. Proceed?")) {
                var doaction = "UpdateClientVouchersCodeId";

                $(document).ajaxStart(function () {
                    $(".clsUserCredit").addClass("aiLoading");
                });
                $(document).ajaxComplete(function () {
                    $(".clsUserCredit").removeClass("aiLoading");
                    $(document).unbind("ajaxStart ajaxStop");
                });
                $.post('GetAjaxData.aspx', { DoAction: doaction, ClientId: clientid, VoucherId: voucherid }, function (responseText) {
                    //alert(responseText.toString());
                    if (responseText.toString() != "") {
                        alert("Voucher code updated successfully");
                        location.href = "purchase_credits.aspx";
                    }
                    else {
                        alert("There was a system error. If this error persists please contact technical support.");
                    }
                });
            }
        }
        else {
            alert("There was a system error. If this error persists please contact technical support.");
        }
    }

</script>

  </asp:Content>