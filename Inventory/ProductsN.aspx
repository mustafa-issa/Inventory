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
	
		        jQuery("#jqgrid").jqGrid({
            
		            url: 'api/products',
		            datatype: "json",
		            height: 'auto',
		            colNames: ['ProductId', 'Title', 'Description', 'Price', 'Quantity', 'Status', 'InsertDate', 'UpdateDate','CategoryId'],
		            colModel: [{
		                name: 'ProductId',
		                index: 'ProductId',
		                sortable: false
		            }, {
		                name: 'Title',
		                index: 'Title'
		            }, {
		                name: 'Description',
		                index: 'Description',
		                editable: true
		            }, {
		                name: 'Price',
		                index: 'Price',
		                editable: true
		            }, {
		                name: 'Quantity',
		                index: 'Quantity',
		                align: "right",
		                editable: true
		            }, {
		                name: 'Status',
		                index: 'Status',
		                align: "right",
		                editable: true
		            }, {
		                name: 'InsertDate',
		                index: 'InsertDate',
		                align: "right",
		                editable: true
		            }, {
		                name: 'note',
		                index: 'note',
		                sortable: false,
		                editable: true
		            },
		            {
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
		                var ids = jQuery("#jqgrid").jqGrid('getDataIDs');  // var gr = jQuery("#jqgrid").jqGrid('getGridParam', 'selrow');
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
		            }

                    ,

		            editurl: "dummy.html",
		            caption: "SmartAdmin jQgrid Skin",
		            multiselect: true,
		            autowidth: true,

		        });




		        jQuery("#jqgrid").jqGrid({
		            url: 'api/products',
		            datatype: "json",
		            colNames: ['ProductId', 'Title', 'Description', 'Price', 'Quantity', 'Status', 'InsertDate', 'UpdateDate', 'CategoryId'],
		            colModel: [{
		                name: 'ProductId',
		                index: 'ProductId',
		                sortable: false
		            }, {
		                name: 'Title',
		                index: 'Title'
		            }, {
		                name: 'Description',
		                index: 'Description',
		                editable: true
		            }, {
		                name: 'Price',
		                index: 'Price',
		                editable: true
		            }, {
		                name: 'Quantity',
		                index: 'Quantity',
		                align: "right",
		                editable: true
		            }, {
		                name: 'Status',
		                index: 'Status',
		                align: "right",
		                editable: true
		            }, {
		                name: 'InsertDate',
		                index: 'InsertDate',
		                align: "right",
		                editable: true
		            }, {
		                name: 'note',
		                index: 'note',
		                sortable: false,
		                editable: true
		            },
		            {
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
		         
		            sortorder: "desc",
		            caption: "Deleteing Example",
		            editurl: "someurl.php"
		        });

		        $("#del_jqgrid").click(function () {
		            var gr = jQuery("#jqgrid").jqGrid('getDataIDs');
		            if (gr != null) jQuery("#jqgrid").jqGrid('delGridRow', gr, { reloadAfterSubmit: false });
		            else alert("Please Select Row to delete!");
		        });




		        jQuery("#jqgrid").jqGrid({
		            url: 'editing.php?q=1',
		            datatype: "xml",
		            colNames: ['ProductId', 'Title', 'Description', 'Price', 'Quantity', 'Status', 'InsertDate', 'UpdateDate', 'CategoryId'],
		            colModel: [{
		                name: 'ProductId',
		                index: 'ProductId',
		                sortable: false
		            }, {
		                name: 'Title',
		                index: 'Title'
		            }, {
		                name: 'Description',
		                index: 'Description',
		                editable: true
		            }, {
		                name: 'Price',
		                index: 'Price',
		                editable: true
		            }, {
		                name: 'Quantity',
		                index: 'Quantity',
		                align: "right",
		                editable: true
		            }, {
		                name: 'Status',
		                index: 'Status',
		                align: "right",
		                editable: true
		            }, {
		                name: 'InsertDate',
		                index: 'InsertDate',
		                align: "right",
		                editable: true
		            }, {
		                name: 'note',
		                index: 'note',
		                sortable: false,
		                editable: true
		            },
		            {
		                name: 'note',
		                index: 'note',
		                sortable: false,
		                editable: true
		            }],
		            rowNum: 10,
		            rowList: [10, 20, 30],
		            pager: '#pagered',
		            sortname: 'id',
		            viewrecords: true,
		            sortorder: "desc",
		            caption: "Editing Example",
		            editurl: "someurl.php"
		        });
		        $("#jqgrid_iledit").click(function () {
		            var gr = jQuery("#jqgrid").jqGrid('getGridParam', 'selrow');
		            if (gr != null) jQuery("#jqgrid").jqGrid('editGridRow', gr, { height: 280, reloadAfterSubmit: false });
		            else alert("Please Select Row");
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

		    }

            )

		 

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
