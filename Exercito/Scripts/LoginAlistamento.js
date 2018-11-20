$(document).ready(function () {

  
    $("#salvar").click(function () {

        var u = $("#Usuario").val();
        var l = $("#LoginCadastro").val();
        var s = $("#SenhaCadastro").val();
        if ($("#Usuario").val() === "" || $("#LoginCadastro").val() === "" || $("#SenhaCadastro").val() === "" || $("#Funcao").val() === "") {
            alert("Faça seu cadastro corretamente");
        } else {
            $.ajax({
                type: "POST",
                url: "/Alistamento/CadastrarLogin",
                data: {
                    "Usuario": $("#Usuario").val(),
                    "Login": $("#LoginCadastro").val(),
                    "Senha": $("#SenhaCadastro").val(),
                    "Funcao": $("#Funcao").val(),
                    

                },
                success:
                    function () {
                           alert("Salvo com sucesso");
                        //window.location = "/Arquivo/"
                    }

            });
        }
    });
    $("#entrar").click(function () {

        if ($("#Login").val() === "" || $("#SenhaLogin").val() === "") {
            alert("Coloque seu Login/Senha corretos.")
        } else {
            $.ajax({
                type: "POST",
                url: "/Alistamento/VerificaUsuario",
                data: {
                    "Login": $("#Login").val(),
                    "SenhaLogin": $("#SenhaLogin").val(),

                },
                success: function (data) {
                    var id = 0;
                    $.each(data, function (i,element) {
                        id = element.Id; 
                    })
                    if (id == 4) {
                        window.location = "/Alistamento/Download/" + id;
                    } else {
                        window.location = "/Alistamento/Loading/" + id;
                    }   
                }
            })
            }
            });
});