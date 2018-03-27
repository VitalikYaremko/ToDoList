webshims.setOptions('forms-ext', {
    replaceUI: 'auto',
    types: 'date'
});
webshims.polyfill('forms forms-ext');
$(function () {
    $('[type="date"].min-today').prop('min', function () {
        return new Date().toJSON().split('T')[0];
    });
});