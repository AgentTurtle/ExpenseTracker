var ViewModel = function () {
    var self = this;
    self.expenses = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();
    self.categories = ko.observableArray();
    self.newExpense = {
        Category: ko.observable(),
        Amount: ko.observable(),
        Description: ko.observable(),
        DueDate: ko.observable()
    }

    var expensesUri = '/api/expenses/';
    var categoriesUri = '/api/categories/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllExpenses() {
        ajaxHelper(expensesUri, 'GET').done(function (data) {
            self.expenses(data);
        });
    }

    self.getExpenseDetail = function (item) {
        ajaxHelper(expensesUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    function getCategories() {
        ajaxHelper(categoriesUri, 'GET').done(function (data) {
            self.categories(data);
        });
    }


    self.addExpense = function (formElement) {
        var expense = {
            CategoryId: self.newExpense.Category().Id,
            Amount: self.newExpense.Amount(),
            Description: self.newExpense.Description(),
            DueDate: self.newExpense.DueDate()
        };

        ajaxHelper(expensesUri, 'POST', expense).done(function (item) {
            self.expenses.push(item);
        });
    }

    // Fetch the initial data.
    getAllExpenses();
    getCategories();
};

ko.applyBindings(new ViewModel());