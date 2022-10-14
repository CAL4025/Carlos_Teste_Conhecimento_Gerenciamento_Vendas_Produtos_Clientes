(function () {
    "use strict";

   $(document).ready(function () {

        $(document).on('click', '#btnExcluirCliente', function () {

            var id = $(this).data('id');


            Swal.fire({
                title: 'Deseja excluir cliente?',
                text: "Esta ação não poderá ser revertida!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sim, exlcuir!'
            }).then((result) => {
                if (result.isConfirmed) {

                    $.ajax({
                        dataType: 'json',
                        type: 'POST',
                        url: '/Clientes/ExcluirCliente',
                        data: { id: id },
                    });

                }
            })
                

        });
   

        $("#btnPesquisarCliente").click(function () {

            Swal.fire({
                title: 'Insira o nome do Cliente.',
                input: 'text',
                inputAttributes: {
                    autocapitalize: 'off'
                },
                showCancelButton: true,
                confirmButtonText: 'Pesquisar',
                showLoaderOnConfirm: true,
                preConfirm: (nome) => {


                    $.ajax({
                        dataType: 'json',
                        type: 'POST',
                        url: '/Clientes/PesquisarCliente',
                        data: { nome: nome }

                        
                    });
                },
                allowOutsideClick: () => !Swal.isLoading()
            })
        });

        $("#btnInserirCliente").click(function () {

            if ($('#nmClienteInserir').val() == '' ||
                $('#cidadeInserir').val() == '' ) {

                Swal.fire('Todos os campos são obrigatórios!')

            }
            else {
                document.form2.submit();
            }
        });

        $("#btnEditarCliente").click(function () {

            if ($('#idClienteEditar').val() == '' ||
                $('#nmClienteEditar').val() == '' ||
                $('#cidadeEditar').val() == ''){

                Swal.fire('Todos os campos são obrigatórios!')

            }
            else {
                document.form3.submit();
            }
        });

   });

})();
