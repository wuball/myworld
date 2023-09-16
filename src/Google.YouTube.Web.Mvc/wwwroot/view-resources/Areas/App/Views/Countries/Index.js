(function () {
    $(function () {

        var _$countriesTable = $('#CountriesTable');
        var _countriesService = abp.services.app.countries;
		var _entityTypeFullName = 'Google.YouTube.Qing.Country';
        
       var $selectedDate = {
            startDate: null,
            endDate: null,
        }

        $('.date-picker').on('apply.daterangepicker', function (ev, picker) {
            $(this).val(picker.startDate.format('MM/DD/YYYY'));
        });

        $('.startDate').daterangepicker({
            autoUpdateInput: false,
            singleDatePicker: true,
            locale: abp.localization.currentLanguage.name,
            format: 'L',
        })
        .on("apply.daterangepicker", (ev, picker) => {
            $selectedDate.startDate = picker.startDate;
            getCountries();
        })
        .on('cancel.daterangepicker', function (ev, picker) {
            $(this).val("");
            $selectedDate.startDate = null;
            getCountries();
        });

        $('.endDate').daterangepicker({
            autoUpdateInput: false,
            singleDatePicker: true,
            locale: abp.localization.currentLanguage.name,
            format: 'L',
        })
        .on("apply.daterangepicker", (ev, picker) => {
            $selectedDate.endDate = picker.startDate;
            getCountries();
        })
        .on('cancel.daterangepicker', function (ev, picker) {
            $(this).val("");
            $selectedDate.endDate = null;
            getCountries();
        });

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Countries.Create'),
            edit: abp.auth.hasPermission('Pages.Countries.Edit'),
            'delete': abp.auth.hasPermission('Pages.Countries.Delete')
        };

         var _createOrEditModal = new app.ModalManager({
                    viewUrl: abp.appPath + 'App/Countries/CreateOrEditModal',
                    scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/Countries/_CreateOrEditModal.js',
                    modalClass: 'CreateOrEditCountryModal'
                });
                   

		 var _viewCountryModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/Countries/ViewcountryModal',
            modalClass: 'ViewCountryModal'
        });

		        var _entityTypeHistoryModal = app.modals.EntityTypeHistoryModal.create();
		        function entityHistoryIsEnabled() {
            return abp.auth.hasPermission('Pages.Administration.AuditLogs') &&
                abp.custom.EntityHistory &&
                abp.custom.EntityHistory.IsEnabled &&
                _.filter(abp.custom.EntityHistory.EnabledEntities, entityType => entityType === _entityTypeFullName).length === 1;
        }

        var getDateFilter = function (element) {
            if ($selectedDate.startDate == null) {
                return null;
            }
            return $selectedDate.startDate.format("YYYY-MM-DDT00:00:00Z"); 
        }
        
        var getMaxDateFilter = function (element) {
            if ($selectedDate.endDate == null) {
                return null;
            }
            return $selectedDate.endDate.format("YYYY-MM-DDT23:59:59Z"); 
        }

        var dataTable = _$countriesTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _countriesService.getAll,
                inputFilter: function () {
                    return {
					filter: $('#CountriesTableFilter').val(),
					nameFilter: $('#NameFilterId').val(),
					regionFilter: $('#RegionFilterId').val(),
					subRegionFilter: $('#SubRegionFilterId').val(),
					englishFilter: $('#EnglishFilterId').val(),
					minLatitudeFilter: $('#MinLatitudeFilterId').val(),
					maxLatitudeFilter: $('#MaxLatitudeFilterId').val(),
					minLongitudeFilter: $('#MinLongitudeFilterId').val(),
					maxLongitudeFilter: $('#MaxLongitudeFilterId').val(),
					minAreaFilter: $('#MinAreaFilterId').val(),
					maxAreaFilter: $('#MaxAreaFilterId').val(),
					callingCodesFilter: $('#CallingCodesFilterId').val(),
					landlockedFilter: $('#LandlockedFilterId').val(),
					capitalFilter: $('#CapitalFilterId').val(),
					flagFilter: $('#FlagFilterId').val(),
					independentFilter: $('#IndependentFilterId').val(),
					organizationFilter: $('#OrganizationFilterId').val(),
					visaFilter: $('#VisaFilterId').val(),
					extraditionFilter: $('#ExtraditionFilterId').val(),
					repatriateFilter: $('#RepatriateFilterId').val(),
					workingVisaFilter: $('#WorkingVisaFilterId').val(),
					proAmericanFilter: $('#ProAmericanFilterId').val(),
					birthrightFilter: $('#BirthrightFilterId').val()
                    };
                }
            },
            columnDefs: [
                {
                    className: 'control responsive',
                    orderable: false,
                    render: function () {
                        return '';
                    },
                    targets: 0
                },
                {
                    width: 120,
                    targets: 1,
                    data: null,
                    orderable: false,
                    autoWidth: false,
                    defaultContent: '',
                    rowAction: {
                        cssClass: 'btn btn-brand dropdown-toggle',
                        text: '<i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span>',
                        items: [
						{
                                text: app.localize('View'),
                                action: function (data) {
                                    _viewCountryModal.open({ id: data.record.country.id });
                                }
                        },
						{
                            text: app.localize('Edit'),
                            visible: function () {
                                return _permissions.edit;
                            },
                            action: function (data) {
                            _createOrEditModal.open({ id: data.record.country.id });                                
                            }
                        },
                        {
                            text: app.localize('History'),
                            iconStyle: 'fas fa-history mr-2',
                            visible: function () {
                                return entityHistoryIsEnabled();
                            },
                            action: function (data) {
                                _entityTypeHistoryModal.open({
                                    entityTypeFullName: _entityTypeFullName,
                                    entityId: data.record.country.id
                                });
                            }
						}, 
						{
                            text: app.localize('Delete'),
                            visible: function () {
                                return _permissions.delete;
                            },
                            action: function (data) {
                                deleteCountry(data.record.country);
                            }
                        }]
                    }
                },
					{
						targets: 2,
						 data: "country.name",
						 name: "name"   
					},
					{
						targets: 3,
						 data: "country.region",
						 name: "region"   
					},
					{
						targets: 4,
						 data: "country.subRegion",
						 name: "subRegion"   
					},
					{
						targets: 5,
						 data: "country.english",
						 name: "english"  ,
						render: function (english) {
							if (english) {
								return '<div class="text-center"><i class="fa fa-check text-success" title="True"></i></div>';
							}
							return '<div class="text-center"><i class="fa fa-times-circle" title="False"></i></div>';
					}
			 
					},
					{
						targets: 6,
						 data: "country.latitude",
						 name: "latitude"   
					},
					{
						targets: 7,
						 data: "country.longitude",
						 name: "longitude"   
					},
					{
						targets: 8,
						 data: "country.area",
						 name: "area"   
					},
					{
						targets: 9,
						 data: "country.callingCodes",
						 name: "callingCodes"   
					},
					{
						targets: 10,
						 data: "country.landlocked",
						 name: "landlocked"  ,
						render: function (landlocked) {
							if (landlocked) {
								return '<div class="text-center"><i class="fa fa-check text-success" title="True"></i></div>';
							}
							return '<div class="text-center"><i class="fa fa-times-circle" title="False"></i></div>';
					}
			 
					},
					{
						targets: 11,
						 data: "country.capital",
						 name: "capital"   
					},
					{
						targets: 12,
						 data: "country.flag",
						 name: "flag"   
					},
					{
						targets: 13,
						 data: "country.independent",
						 name: "independent"  ,
						render: function (independent) {
							if (independent) {
								return '<div class="text-center"><i class="fa fa-check text-success" title="True"></i></div>';
							}
							return '<div class="text-center"><i class="fa fa-times-circle" title="False"></i></div>';
					}
			 
					},
					{
						targets: 14,
						 data: "country.organization",
						 name: "organization"   
					},
					{
						targets: 15,
						 data: "country.visa",
						 name: "visa"   
					},
					{
						targets: 16,
						 data: "country.extradition",
						 name: "extradition"   
					},
					{
						targets: 17,
						 data: "country.repatriate",
						 name: "repatriate"   
					},
					{
						targets: 18,
						 data: "country.workingVisa",
						 name: "workingVisa"   
					},
					{
						targets: 19,
						 data: "country.proAmerican",
						 name: "proAmerican"  ,
						render: function (proAmerican) {
							if (proAmerican) {
								return '<div class="text-center"><i class="fa fa-check text-success" title="True"></i></div>';
							}
							return '<div class="text-center"><i class="fa fa-times-circle" title="False"></i></div>';
					}
			 
					},
					{
						targets: 20,
						 data: "country.birthright",
						 name: "birthright"  ,
						render: function (birthright) {
							if (birthright) {
								return '<div class="text-center"><i class="fa fa-check text-success" title="True"></i></div>';
							}
							return '<div class="text-center"><i class="fa fa-times-circle" title="False"></i></div>';
					}
			 
					}
            ]
        });

        function getCountries() {
            dataTable.ajax.reload();
        }

        function deleteCountry(country) {
            abp.message.confirm(
                '',
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _countriesService.delete({
                            id: country.id
                        }).done(function () {
                            getCountries(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        }

		$('#ShowAdvancedFiltersSpan').click(function () {
            $('#ShowAdvancedFiltersSpan').hide();
            $('#HideAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideDown();
        });

        $('#HideAdvancedFiltersSpan').click(function () {
            $('#HideAdvancedFiltersSpan').hide();
            $('#ShowAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideUp();
        });

        $('#CreateNewCountryButton').click(function () {
            _createOrEditModal.open();
        });        

		$('#ExportToExcelButton').click(function () {
            _countriesService
                .getCountriesToExcel({
				filter : $('#CountriesTableFilter').val(),
					nameFilter: $('#NameFilterId').val(),
					regionFilter: $('#RegionFilterId').val(),
					subRegionFilter: $('#SubRegionFilterId').val(),
					englishFilter: $('#EnglishFilterId').val(),
					minLatitudeFilter: $('#MinLatitudeFilterId').val(),
					maxLatitudeFilter: $('#MaxLatitudeFilterId').val(),
					minLongitudeFilter: $('#MinLongitudeFilterId').val(),
					maxLongitudeFilter: $('#MaxLongitudeFilterId').val(),
					minAreaFilter: $('#MinAreaFilterId').val(),
					maxAreaFilter: $('#MaxAreaFilterId').val(),
					callingCodesFilter: $('#CallingCodesFilterId').val(),
					landlockedFilter: $('#LandlockedFilterId').val(),
					capitalFilter: $('#CapitalFilterId').val(),
					flagFilter: $('#FlagFilterId').val(),
					independentFilter: $('#IndependentFilterId').val(),
					organizationFilter: $('#OrganizationFilterId').val(),
					visaFilter: $('#VisaFilterId').val(),
					extraditionFilter: $('#ExtraditionFilterId').val(),
					repatriateFilter: $('#RepatriateFilterId').val(),
					workingVisaFilter: $('#WorkingVisaFilterId').val(),
					proAmericanFilter: $('#ProAmericanFilterId').val(),
					birthrightFilter: $('#BirthrightFilterId').val()
				})
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        abp.event.on('app.createOrEditCountryModalSaved', function () {
            getCountries();
        });

		$('#GetCountriesButton').click(function (e) {
            e.preventDefault();
            getCountries();
        });

		$(document).keypress(function(e) {
		  if(e.which === 13) {
			getCountries();
		  }
		});

        $('.reload-on-change').change(function(e) {
			getCountries();
		});

        $('.reload-on-keyup').keyup(function(e) {
			getCountries();
		});

        $('#btn-reset-filters').click(function (e) {
            $('.reload-on-change,.reload-on-keyup,#MyEntsTableFilter').val('');
            getCountries();
        });
		
		
		

    });
})();
