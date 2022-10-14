(function () {
    "use strict";

    $(document).ready(function () {

        $(document).on('click','#btnExcluirProduto',function () {
            
            var id = $(this).data('id');

            Swal.fire({
                title: 'Deseja excluir produto?',
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
                        url: '/Produtos/ExcluirProduto',
                        data: { id: id },

                    });
                   
                }
            })
        });

        $("#btnPesquisarProduto").click(function () {

            Swal.fire({
                title: 'Insira o nome do Produto.',
                input: 'text',
                inputAttributes: {
                    autocapitalize: 'off'
                },
                showCancelButton: true,
                confirmButtonText: 'Pesquisar',
                showLoaderOnConfirm: true,
                preConfirm: (nome) => {
                    
                    $("tr.tabelaProdutos").remove();
                    
                    $.ajax({
                        dataType: 'json',
                        type: 'POST',
                        url: '/Produtos/PesquisarProduto',
                        data: { nome: nome }

                       
                    });
                },
                allowOutsideClick: () => !Swal.isLoading()
            })
        });

        $("#btnInserirProduto").click(function () {

            if ($('#idProdutoInserir').val() == '' ||
                $('#vlrUnitárioProdutoInserir').val() == '')
            {

                Swal.fire('Todos os campos são obrigatórios!')

            }
            else {
                document.form2.submit();
            }
        });

        $("#btnProdutoEditar").click(function () {

            if ($('#idProdutoEditar').val() == '' ||
                $('#dscProdutoEditar').val() == '' ||
                $('#vlrUnitarioEditar').val() == '' ) {

                Swal.fire('Todos os campos são obrigatórios!')

            }
            else {
                document.form3.submit();
            }
        });
    });
})();
