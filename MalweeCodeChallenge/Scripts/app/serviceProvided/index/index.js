$(document).ready(function () {
    var str = 0;

    $("#SelectFilter")
        .change(function () {
            str = $("select option:selected").val();
            switch (str) {
                case "0":
                    $('#filter').maskMoney('unmasked');

                    break;
                case "1":
                    $('#filter').maskMoney('unmasked');
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    $('#filter').maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: true });
                    break;
                case "6":
                    $('#filter').maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: true });
                    break;

                default:
            }
        });

    $('#btnApplyFilter').click(function () {
        var filterType = $('#SelectFilter').val();
        var filter = $('#filter').val();

        $.ajax({
            url: 'ServiceProvideds/Filter',
            type: 'POST',
            data: {
                filterDto: {
                    FilterType: filterType,
                    FilterValue: filter
                }

            },
            success: (result) => {
                $("#servicesGrid").html(result);
            },
            error: (XMLHttpRequest, textStatus, errorThrown) => {
                swal("Erro", textStatus, "error");

            }
        });
    });

});