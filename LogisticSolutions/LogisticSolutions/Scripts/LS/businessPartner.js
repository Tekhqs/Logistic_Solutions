///+++++++++++++++++++++++++++++++++++++++++++++++++++++++++CREATING BUSINESS PARTNER IMPLEMENTATION START +++++++++++++++++++++++++++//
var partnerID = "";
var BillingAddressID = "";
var ShippingAddressID = "";
var businessPartner = "";

    (function ($) {
        $.fn.serializeFormJSON = function () {

            var o = {};
            var a = this.serializeArray();
            $.each(a, function () {
                if (o[this.name]) {
                    if (!o[this.name].push) {
                        o[this.name] = [o[this.name]];
                    }
                    o[this.name].push(this.value || '');
                } else {
                    o[this.name] = this.value || '';
                }
            });
            return o;
        };
    })(jQuery);
    function toJSONString(divid) {

        var obj = {};
        //var elements = $('#step-1').querySelectorAll("input, select, textarea");
        var elements = $('#' + divid + '').children();
        $('#' + divid + '').find('input:text,input:radio:checked,input:checkbox:checked, input:password, input:file, select, textarea').each(function () {
            // $(this).val('');
            if ($(this)) {
                var name = $(this).prop('name');
                obj[name] = $(this).val();
            }
        });
        return obj;
    }
    function updateBusinessPartnerBillShipAddress(businessPartner, partnerID, BillingAddressID, ShippingAddressID) {

        $.ajax({
            type: 'PUT',
            data: JSON.stringify(businessPartner),
            url: "/api/BusinessPartner?PartnerID=" + partnerID + "&BillingAddressID=" + BillingAddressID + "&ShippingAddressID=" + ShippingAddressID,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (data) {
               
                window.location.href = '/BusinessPartner/BusinessPartners/Index';
            }
        });
    }
    function saveBillingAddress(businessPartner, partnerID) {
        if (businessPartner.Address1 == "" || businessPartner.Address1 == undefined)
            return;
        $.ajax({
            type: 'POST',
            data: JSON.stringify(businessPartner),
            url: "/api/BusinessPartnerBillAdress?PartnerID=" + partnerID,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (data) {
                debugger;
                partnerID = data.PartnerID;
                BillingAddressID = data.BillingAddressID;

                saveShippingAddress(businessPartner, partnerID, BillingAddressID)
            }
        });
    }
    function saveShippingAddress(businessPartner, partnerID, BillingAddressID) {
        debugger;
        if (businessPartner.ShipAddress1 == "" || businessPartner.ShipAddress2 == undefined)
            return;
        $.ajax({
            type: 'POST',
            data: JSON.stringify(businessPartner),
            url: "/api/BusinessPartnerShipAdress?PartnerID=" + partnerID,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (data) {
                debugger;
                ShippingAddressID = data.ShippingAddressID;

                updateBusinessPartnerBillShipAddress(businessPartner, partnerID, BillingAddressID, ShippingAddressID)
            }
        });
    }
    function PostBusinessPartner()
    {
        //var businessPartnerForm = $("#addBusinessPartnerForm").kendoValidator().data("kendoValidator");
    var businessPartnerForm = $("#addBusinessPartnerForm").kendoValidator({
        messages: {
            custom: "Billing Country is Required",
            custom1: "Shipping Country is Required",
        },
        rules: {
            custom: function (select) {
                if (select.is("[name=CountryID]")) {
                    return select.val() != "-1";
                }
                return true;
            },
            custom1: function (select) {
                if (select.is("[name=ShipCountryID]")) {
                    return select.val() != "-1";
                }
                return true;
            }
        }
    }).data("kendoValidator");
        if (!businessPartnerForm.validate()) 
        {
                return false;
        }
        else
        {

             businessPartner = toJSONString('divAddBusinessPartner');
                 console.log(businessPartner);

                $.ajax({
                    type: 'POST',
                    data: JSON.stringify(businessPartner),
                    url: "/api/BusinessPartner",
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    error: function (error) {
                        debugger;
                        if (error.statusText == "Conflict") {
                            $("#ExistsID").css({ "display": "block" });

                            document.body.scrollTop = 0; // For Safari
                            document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
                        }
                        
                    },
                    success: function (data) {
                        debugger;
                       
                        
                            partnerID = data.PartnerID;
                            saveBillingAddress(businessPartner, partnerID);
                       

                       


                    }
                });
        }
        
    }
///+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++CREATING BUSINESS PARTNER IMPLEMENTATION END +++++++++++++++++++++++++++++++// 
///++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ASSIGNING SHIPPING RATE IMPLEMENTATION START++++++++++++++++++++++++++++//
function openDetail(btn) 
{    
        var btn = $(btn).attr('data-index');
        var heading = "";
        if (btn == "1")
        {
            heading = "Inbound Handling (Recieving)";
            $("#extraDetail").hide();
        }
        else if (btn == "2")
        {
            heading = "Storage";
            $("#extraDetail").show();
        }
        else if (btn == "3")
        {
            heading = "Outbound Fulfillment Service(Shipping Orders) (up to 400 SKU)";
            $("#extraDetail").hide();
        }
        else if (btn == "4")
        {
            heading = "Return Management Services";
            $("#extraDetail").hide();
        }
        else if (btn == "5")
        {
            heading = "Other Services";
            $("#extraDetail").hide();
        }
        else if (btn == "6")
        {
            heading = "Labor Charges (Inspection, Rework, Replenishment & etc.)";
            $("#extraDetail").hide();
        }
        $("#billDetailHeader").text(heading);
        $("#tblShipDetail").empty();
        $("#divShippingRate").load('/BusinessPartner/BusinessPartners/_ShippingRatesDetail?shippingRateTypeID=' + btn);
setTimeout(function()
        {
            $('#billinDetailModal').modal('show');

        }, 500);
        
    }
///++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ASSIGNING SHIPPING RATE IMPLEMENTATION END ++++++++++++++++++++++++++++++++++//