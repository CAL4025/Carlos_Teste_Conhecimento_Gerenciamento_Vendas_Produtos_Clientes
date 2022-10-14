(function () {
    "use strict";

    $(document).ready(function () {


        $(document).on('click', '#btnExcluirVenda', function () {

            var id = $(this).data('id');

            Swal.fire('Teste aviso!')

            Swal.fire({
                title: 'Deseja excluir a venda?',
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
                        url: '/Vendas/ExcluirVenda',
                        data: { id: id },
                        
                    });

                }
            })
        });
    

        $("#btnPesquisarVenda").click(function () {

            Swal.fire({
                title: 'Insira o nome do Cliente ou descrição do Produto.',
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
                        url: '/Vendas/PesquisarVenda',
                        data: { nome: nome }

                       
                    });
                },
                allowOutsideClick: () => !Swal.isLoading()
            })
        });

        $("#btnInserirVenda").click(function () {

            if ($('#idClienteVendaInserir').val() == '' ||
                $('#idProdutoVendaInserir').val() == '' ||
                $('#qtdVendaInserir').val() == '' ||
                $('#dtVendaInserir').val() == '') {

                Swal.fire('Todos os campos são obrigatórios!')

            }
            else {
                document.form2.submit();
            }
        });

        $("#btnVendaEditar").click(function () {

            if ($('#idClienteVendaEditar').val() == '' ||
                $('#idProdutVendaoEditar').val() == '' ||
                $('#qtdVendaEditar').val() == '' ||
                $('#dthVendaEditar').val() == '') {

                Swal.fire('Todos os campos são obrigatórios!')

            }
            else {
                document.form3.submit();
            }
        });

    });

})();
