let mark = $("#MarkId");
mark.on("change", function () {
    let model = $("#ModelId");
    model.empty();
    let selected = $(this).children("option:selected").val();
    if (this.selectedIndex === 0) model.parent().hide(1000);
    else {
        $.getJSON("/Car/GetModels/" + selected, function (data) {
            model.append($("<option></option>")
                .attr("value", "")
                .text("Select a model"));
            $.each(data, function (key, data) {
                model.append($("<option></option>")
                    .attr("value", data.Value)
                    .text(data.Text));
            });
            model.parent().show(1000);
        });
    }
});