﻿"use strict";

// Class definition
var KTJKanbanDemoColor = function() {
    // Private functions
    var exampleColor = function() {
        var kanban = new jKanban({
            element: '#kt_docs_jkanban_color',
            gutter: '0',
            widthBoard: '250px',
            boards: [{
                    'id': '_inprocess',
                    'title': 'In Process',
                    'class': 'primary',
                    'item': [{
                            'title': '<span class="fw-bold">You can drag me too</span>',
                            'class': 'light-primary',
                        },
                        {
                            'title': '<span class="fw-bold">Buy Milk</span>',
                            'class': 'light-primary',
                        }
                    ]
                }, {
                    'id': '_working',
                    'title': 'Working',
                    'class': 'success',
                    'item': [{
                            'title': '<span class="fw-bold">Do Something!</span>',
                            'class': 'light-success',
                        },
                        {
                            'title': '<span class="fw-bold">Run?</span>',
                            'class': 'light-success',
                        }
                    ]
                }, {
                    'id': '_done',
                    'title': 'Done',
                    'class': 'danger',
                    'item': [{
                            'title': '<span class="fw-bold">All right</span>',
                            'class': 'light-danger',
                        },
                        {
                            'title': '<span class="fw-bold">Ok!</span>',
                            'class': 'light-danger',
                        }
                    ]
                }
            ]
        });
    }

    return {
        // Public Functions
        init: function() {
            exampleColor();
        }
    };
}();

// On document ready
KTUtil.onDOMContentLoaded(function() {
    KTJKanbanDemoColor.init();
});
