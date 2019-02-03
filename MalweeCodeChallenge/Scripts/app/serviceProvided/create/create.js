$(document).ready(function () {

    $("#Description").css({ "margin": "0px", "width": "100%", "height": "100px" });


    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd;
    }

    if (mm < 10) {
        mm = '0' + mm;
    }


    today = yyyy + '-' + mm + '-' + dd;

    $("#DateOfService").val(today);
    $('#Value').maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: true });

    $('#btnSave').click(function () {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var description = $('#Description').val();
        var service = $('#SelectServiceSel2').val();
        var dateOfService = $('#DateOfService').val();
        var value = ($('#Value').maskMoney('unmasked')[0]).toString().replace('.',',');
        $.ajax({
            url: 'Create',
            type: 'POST',
            data: {
                __RequestVerificationToken: token,
                serviceProvided: {
                    Description: description,
                    Service: service,
                    DateOfService: dateOfService,
                    Value: value
                }

            },
            success: (result) =>  {
                if(result.success){
                    swal("Sucesso", "Salvo com sucesso.", "success");
                    $('#Description').val(' ');
                    $('#Value').val(' ');
                    $('#DateOfService').val(today);

                }else{
                    swal("Erro", result.message, "error");

                }
            },
            error : (XMLHttpRequest, textStatus, errorThrown)=> {
                swal("Erro", XMLHttpRequest.message, "error");

            }
        });
        return false;
    });

});