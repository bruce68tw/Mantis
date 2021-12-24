var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'projectName' },
                { data: 'summary' },
                { data: 'statusName' },
                { data: 'userName' },
                { data: 'os_build' },
                { data: 'created' },
            ],
            columnDefs: [
                _crud.dtColDef,
				{ targets: [5], render: function (data, type, full, meta) {
                    return _date.tsToUiDt(data);
                }},
            ],
        };

        //initial
        _crud.init(config);
    },

}; //class