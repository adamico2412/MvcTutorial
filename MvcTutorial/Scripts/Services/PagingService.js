function PagingService(resultList) {
    var self = this;
    self.queryOptions = {
        currentPage: ko.observable(),
        totalPages: ko.observable(),
        pageSize: ko.observable(),
        sortField: ko.observable(),
        sortOrder: ko.observable()
    };

    self.entities = ko.observableArray();

    self.updateResultList = function (resultList) {
        self.queryOptions.currentPage(resultList.queryOptions.currentPage);
        self.queryOptions.totalPages(resultList.queryOptions.totalPages);
        self.queryOptions.pageSize(resultList.queryOptions.pageSize);
        self.queryOptions.sortField(resultList.queryOptions.sortField);
        self.queryOptions.sortOrder(resultList.queryOptions.sortOrder);
        self.entities(resultList.results);
    };

    self.updateResultList(resultList);

    self.sortEntitiesBy = function (data, event) {
        var sortField = $(event.target).data('sortField');

        if (sortField == self.queryOptions.sortField() && self.queryOptions.sortOrder() == 'ASC')
            self.queryOptions.sortOrder('DESC');
        else
            self.queryOptions.sortOrder('ASC');

        self.queryOptions.sortField(sortField);
        self.queryOptions.currentPage(1);

        self.fetchEntities(event);
    };

    self.previousPage = function (data, event) {
        if (self.queryOptions.currentPage > 1) {
            self.queryOptions.currentPage(self.queryOptions.currentPage() - 1);
            self.fetchEntities(event);
        }
    };

    self.nextPage = function (data, event) {
        if (self.queryOptions.currentPage < self.queryOptions.totalPages()) {
            self.queryOptions.currentPage(self.queryOptions.currentPage() + 1);
            self.fetchEntities(event);
        }
    };

    self.fetchEntities = function (event) {
        var url = '/api/' + $(event.target).attr('href');
        url += "?sortField=" + self.queryOptions.sortField();
        url += "&sortOrder=" + self.queryOptions.sortOrder();
        url += "&currentPage=" + self.queryOptions.currentPage();
        url += "&pageSize=" + self.queryOptions.pageSize();

        $.ajax({
            dataType: 'json',
            url: url
        }).success(function (data) {
            self.updateResultList(data);
        }).error(function (err) {
            console.log(err);
        });
    };

    self.buildSortIcon = function (sortField) {
        //logic to build sort icon goes here

        return 'glyphicon glyphicon-sort-by-alphabet';
    }

    self.buildPreviousClass = ko.pureComputed(function () {
        var className = 'previous';

        if (self.queryOptions.currentPage() == 1)
            className += ' disabled';

        return className;
    });

    self.buildNextClass = ko.pureComputed(function () {
        var className = 'next';

        if (self.queryOptions.currentPage() == self.queryOptions.totalPages())
            className += ' disabled';

        return className;
    });
}