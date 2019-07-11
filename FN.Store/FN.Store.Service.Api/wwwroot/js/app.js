//IIF
(function () {

    var _url = "http://fnstore.azurewebsites.net/api/clientes/";


    function obterClientes() {
        $.ajax({
            url: _url,
            method: "get",
            beforeSend: function () {
                $("table").hide();
                $(".loading").show();
            },
            complete: function () {
                $(".loading").hide();
                $("table").show();
            },
            success: function (resp) {
                $("tbody").empty();

                $.each(resp, function (i, cli) {
                    var $tr = $("<tr/>");
                    $("<td/>").append(cli.Nome).appendTo($tr);
                    $("<td/>").append(cli.Idade).appendTo($tr);
                    $("<td/>").append(cli.Sexo == 0 ? "Fem" : "Masc").appendTo($tr);
                    $("<td/>").append(cli.DataCadastro).appendTo($tr);

                    $("<td/>").append("<button data-id='"+ cli.Id+"' class='btn btn-sm btn-danger btn-del'>Excluir</button>").appendTo($tr);

                    $("tbody").append($tr);
                });

                $("button.btn-del").click(excluir);

            }
        });
    }

    function salvarCliente() {
        var data = {};
        data.nome = $("#nomeTxt").val();
        data.idade = $("#idadeTxt").val();
        data.sexo = $("#sexoDdl").val();

        var post = $.post(_url, data).done(function (retorno) {
            //console.log(retorno);
            toastr.success("Cliente cadastrado");
            limparForm();
            obterClientes();
        }).always(function () {
            //console.log(post.readyState);
            if (post.status >= 400) {
                toastr.error("Não foi possível salvar esse cliente");
            }
            //console.log(post.statusText);
        });

    }

    function limparForm() {
        $("#nomeTxt").val('').focus();
        $("#idadeTxt").val('');
        $("#sexoDdl").val('');
    }

    function excluir() {
        var id = $(this).data("id");
        $.ajax({
            url:_url + id,
            type: "delete",
            success: function () {
                toastr.success("Cliente excluído");
                obterClientes();
            }
        });
    }

    $("#limparBtn").click(limparForm);
    $("#salvarBtn").click(salvarCliente);
    obterClientes();

})();
