

Ext.define('Ext.ux.SimplePagingToolbar', {
    extend: 'Ext.toolbar.Paging',
    alias: 'widget.simplepagingtoolbar',

    cls: 'x-toolbar-paging',

    // Override parent
    initComponent: function () {
        var me = this;

        me.store = Ext.Object.merge({}, me.store, {
            getCount: function () {
                return me.f_recordCount;
            },
            currentPage: me.f_pageIndex + 1
        });

        me.callParent();
    },

    // Override parent
    getPagingItems: function() {
        var items = this.callParent();
        // Remove refresh and separator items.
        return items.slice(0, items.length - 2);
    },

    // Override parent
    getPageData: function () {
        var fromRecord = 0, toRecord = 0;
        if (this.f_databasePaging) {
            fromRecord = (this.f_pageIndex * this.f_pageSize) + 1;
            toRecord = fromRecord + this.f_pageSize - 1;
        } else {
            fromRecord = this.f_startRowIndex + 1;
            toRecord = this.f_endRowIndex + 1;
        }
        if (toRecord > this.f_recordCount) {
            toRecord = this.f_recordCount;
        }

        return {
            total: this.f_recordCount,
            currentPage: this.f_pageIndex + 1,
            pageCount: this.f_pageCount <= 0 ? 1 : this.f_pageCount,
            fromRecord: fromRecord,
            toRecord: toRecord
        };
    },

    f_update: function (configs) {
        Ext.Object.merge(this, configs);
        this.store.currentPage = this.f_pageIndex + 1;
        this.onLoad();

        // 非服务端分页，则需要重新计算 f_startRowIndex 和  f_endRowIndex
        if (!this.f_databasePaging) {
            var startRowIndex = this.f_pageSize * this.f_pageIndex;
            var endRowIndex = (this.f_pageIndex + 1) * this.f_pageSize - 1;
            if(endRowIndex > this.f_recordCount - 1) {
                endRowIndex = this.f_recordCount - 1;
            }
            
            this.f_startRowIndex = startRowIndex;
            this.f_endRowIndex = endRowIndex;
        }
    }

});
