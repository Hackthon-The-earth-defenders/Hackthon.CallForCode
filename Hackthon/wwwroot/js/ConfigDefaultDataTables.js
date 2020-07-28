/*  Criado por Leonardo Dorathoto em 27/10/2016
    Modificado em:

 Configura o DataTables.net com um configuração default
 */

function LoadConfigDefaultDataTableNet() {
    $.extend(true, $.fn.dataTable.defaults, {
        "pageLength": 25,
        "lengthMenu": [[25, 50, 100, 200, 500, -1], [25, 50, 100, 200, 500, "All"]],
        "language": {
            "url": "/lib/dataTablesPortuguese-Brasil.json"
        }
    });
}
