/**
 * Main client script
 *
 */
$(document).ready(function () {

    /**
    * jQuery Ajax helper for PUT method
    */
    $.put = function (url, data, callback, type) {

        if ($.isFunction(data)) {
            type = type || callback,
            callback = data,
            data = {}
        }

        return $.ajax({
            url: url,
            type: 'PUT',
            success: callback,
            data: data,
            contentType: type
        });
    }

    /**
     * Appends row to the table body
     *
     * @param {tbody} tbody table body.
     * @param {Number} index
     * @param {Number} name Person name.
     * @param {Number} gender 1 - male, 0 - female
     * @param {Number} age
     * @name appendRow
     */
    function appendRow(tbody, index, name, gender, age) {
        tbody
                .append($('<tr>')
                    .append($('<th>')
                        .attr('scope', 'row')
                        .text(index)
                    )
                    .append($('<td>')
                        .text(name)
                    )
                    .append($('<td>')
                        .text(gender)
                    )
                    .append($('<td>')
                        .text(age)
                    )
                );
    }

    /**
     * api/data/person Handler
     */
    $('#get-people').click(function (e) {
        $.get("api/data/person", function (data, status) {
            var tbody = $("#persons-table").find('tbody');

            tbody.empty();

            $.each(data, function (index, el) {
                appendRow(tbody, index + 1, el.Name, el.Gender, el.Age);
            });
        });
    });

    /**
     * api/data/person/filter Handler
     */
    $('#filter-people').click(function (e) {
        $.get("api/data/person/filter", function (data, status) {
            var tbody = $("#filtered-table").find('tbody');

            tbody.empty();

            $.each(data, function (index, el) {
                appendRow(tbody, index + 1, el.Name, el.Gender, el.Age);
            });
        });
    });

    /**
     * api/data/person/filter Handler
     */
    $('#add-person').click(function (e) {
        $.put("api/data/person/random", function (data, status) {
            
            $("#modal-content").text(data);
            $('.add-person-modal').modal('show');
        });
    });
});
