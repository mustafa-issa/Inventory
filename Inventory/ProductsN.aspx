<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductsN.aspx.cs" Inherits="Inventory.ProductsN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="widget-grid" class="">

					<!-- row -->
					<div class="row">

						<!-- NEW WIDGET START -->
						<article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">

							<table id="jqgrid"></table>
							<div id="pjqgrid"></div>

							<br>
							<a href="javascript:void(0)" id="m1">Get Selected id's</a>
							<br>
							<a href="javascript:void(0)" id="m1s">Select(Unselect) row 13</a>

						</article>
						<!-- WIDGET END -->

					</div>

					<!-- end row -->

				</section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script src="js/plugin/jqgrid/jquery.jqGrid.min.js"></script>
		<script src="js/plugin/jqgrid/grid.locale-en.min.js"></script>

		<script type="text/javascript">
		    $(document).ready(function () {
		        pageSetUp();
		   
		        var jqgrid_data = "data/1.json";

		        jQuery("#jqgrid").jqGrid({
		            data: jqgrid_data,
		            datatype: "local",
		            height: 'auto',
		            colNames: ['Actions', 'Inv No', 'Date', 'Client', 'Amount', 'Tax', 'Total', 'Notes'],
		            colModel: [{
		                name: 'act',
		                index: 'act',
		                sortable: false
		            }, {
		                name: 'id',
		                index: 'id'
		            }, {
		                name: 'date',
		                index: 'date',
		                editable: true
		            }, {
		                name: 'name',
		                index: 'name',
		                editable: true
		            }, {
		                name: 'amount',
		                index: 'amount',
		                align: "right",
		                editable: true
		            }, {
		                name: 'tax',
		                index: 'tax',
		                align: "right",
		                editable: true
		            }, {
		                name: 'total',
		                index: 'total',
		                align: "right",
		                editable: true
		            }, {
		                name: 'note',
		                index: 'note',
		                sortable: false,
		                editable: true
		            }],
		            rowNum: 10,
		            rowList: [10, 20, 30],
		            pager: '#pjqgrid',
		            sortname: 'id',
		            toolbarfilter: true,
		            viewrecords: true,
		            sortorder: "asc",
		            gridComplete: function () {
		                var ids = jQuery("#jqgrid").jqGrid('getDataIDs');
		                for (var i = 0; i < ids.length; i++) {
		                    var cl = ids[i];
		                    be = "<button class='btn btn-xs btn-default' data-original-title='Edit Row' onclick=\"jQuery('#jqgrid').editRow('" + cl + "');\"><i class='fa fa-pencil'></i></button>";
		                    se = "<button class='btn btn-xs btn-default' data-original-title='Save Row' onclick=\"jQuery('#jqgrid').saveRow('" + cl + "');\"><i class='fa fa-save'></i></button>";
		                    ca = "<button class='btn btn-xs btn-default' data-original-title='Cancel' onclick=\"jQuery('#jqgrid').restoreRow('" + cl + "');\"><i class='fa fa-times'></i></button>";
		                    //ce = "<button class='btn btn-xs btn-default' onclick=\"jQuery('#jqgrid').restoreRow('"+cl+"');\"><i class='fa fa-times'></i></button>";
		                    //jQuery("#jqgrid").jqGrid('setRowData',ids[i],{act:be+se+ce});
		                    jQuery("#jqgrid").jqGrid('setRowData', ids[i], {
		                        act: be + se + ca
		                    });
		                }
		            },
		            editurl: "dummy.html",
		            caption: "SmartAdmin jQgrid Skin",
		            multiselect: true,
		            autowidth: true,

		        });
		        jQuery("#jqgrid").jqGrid('navGrid', "#pjqgrid", {
		            edit: false,
		            add: false,
		            del: true
		        });
		        jQuery("#jqgrid").jqGrid('inlineNav', "#pjqgrid");
		        /* Add tooltips */
		        $('.navtable .ui-pg-button').tooltip({
		            container: 'body'
		        });

		        jQuery("#m1").click(function () {
		            var s;
		            s = jQuery("#jqgrid").jqGrid('getGridParam', 'selarrrow');
		            alert(s);
		        });
		        jQuery("#m1s").click(function () {
		            jQuery("#jqgrid").jqGrid('setSelection', "13");
		        });

		        // remove classes
		        $(".ui-jqgrid").removeClass("ui-widget ui-widget-content");
		        $(".ui-jqgrid-view").children().removeClass("ui-widget-header ui-state-default");
		        $(".ui-jqgrid-labels, .ui-search-toolbar").children().removeClass("ui-state-default ui-th-column ui-th-ltr");
		        $(".ui-jqgrid-pager").removeClass("ui-state-default");
		        $(".ui-jqgrid").removeClass("ui-widget-content");

		        // add classes
		        $(".ui-jqgrid-htable").addClass("table table-bordered table-hover");
		        $(".ui-jqgrid-btable").addClass("table table-bordered table-striped");

		        $(".ui-pg-div").removeClass().addClass("btn btn-sm btn-primary");
		        $(".ui-icon.ui-icon-plus").removeClass().addClass("fa fa-plus");
		        $(".ui-icon.ui-icon-pencil").removeClass().addClass("fa fa-pencil");
		        $(".ui-icon.ui-icon-trash").removeClass().addClass("fa fa-trash-o");
		        $(".ui-icon.ui-icon-search").removeClass().addClass("fa fa-search");
		        $(".ui-icon.ui-icon-refresh").removeClass().addClass("fa fa-refresh");
		        $(".ui-icon.ui-icon-disk").removeClass().addClass("fa fa-save").parent(".btn-primary").removeClass("btn-primary").addClass("btn-success");
		        $(".ui-icon.ui-icon-cancel").removeClass().addClass("fa fa-times").parent(".btn-primary").removeClass("btn-primary").addClass("btn-danger");

		        $(".ui-icon.ui-icon-seek-prev").wrap("<div class='btn btn-sm btn-default'></div>");
		        $(".ui-icon.ui-icon-seek-prev").removeClass().addClass("fa fa-backward");

		        $(".ui-icon.ui-icon-seek-first").wrap("<div class='btn btn-sm btn-default'></div>");
		        $(".ui-icon.ui-icon-seek-first").removeClass().addClass("fa fa-fast-backward");

		        $(".ui-icon.ui-icon-seek-next").wrap("<div class='btn btn-sm btn-default'></div>");
		        $(".ui-icon.ui-icon-seek-next").removeClass().addClass("fa fa-forward");

		        $(".ui-icon.ui-icon-seek-end").wrap("<div class='btn btn-sm btn-default'></div>");
		        $(".ui-icon.ui-icon-seek-end").removeClass().addClass("fa fa-fast-forward");

		    })

		    $(window).on('resize.jqGrid', function () {
		        $("#jqgrid").jqGrid('setGridWidth', $("#content").width());
		    })

        </script>

		<!-- Your GOOGLE ANALYTICS CODE Below -->
		<script type="text/javascript">
		    var _gaq = _gaq || [];
		    _gaq.push(['_setAccount', 'UA-XXXXXXXX-X']);
		    _gaq.push(['_trackPageview']);

		    (function () {
		        var ga = document.createElement('script');
		        ga.type = 'text/javascript';
		        ga.async = true;
		        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
		        var s = document.getElementsByTagName('script')[0];
		        s.parentNode.insertBefore(ga, s);
		    })();

		</script>
</asp:Content>
