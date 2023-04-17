 k = $.cookie("font-cookie");
 var z = $.cookie("size-cookie"),
 u = $.cookie("lineheight-cookie"),
 B = $.cookie("fluid-switch-cookie"),
 C = $.cookie("onebreak-switch-cookie"),
 v = $("#chapter-bnum").val(),
 w = $("#chapter-num").val();
 1 == $("#chapter-sac").val() && ga("send", "event", "truyensac");
 k ? $("#font-chu").val(k) : $.browser.mobile && $("#font-chu").val("Arial, sans-serif");
 z ? $("#size-chu").val(z) : $.browser.mobile || $("#size-chu").val("22px");
 u && "180%" != u ? $("#line-height").val(u) : $("#line-height").val("180%");
 1 == B && ($("#fluid-no").attr("checked", !1), $("#fluid-yes").attr("checked", !0));
 1 == C ? ($("#onebreak-no").attr("checked", !1), $("#onebreak-yes").attr("checked", !0)) : (original_content = $(".chapter-c").html());
 $("#font-chu").on("change", function () {
    var a = this.value;
    $(".chapter-c").css("font-family", a);
    $.cookie("font-cookie", a, { expires: 365, path: "/" });
});
 $("#size-chu").on("change", function () {
    var a = this.value;
    $(".chapter-c").css("font-size", a);
    $.cookie("size-cookie", a, { expires: 365, path: "/" });
});
 $("#line-height").on("change", function () {
    var a = this.value;
    $(".chapter-c").css("line-height", a);
    $.cookie("lineheight-cookie", a, { expires: 365, path: "/" });
});
 $(document.body).on("click", ".chapter .toggle-nav-open", function () {
    1 == $.cookie("hidenav-cookie")
    ? ($(".navbar").slideDown(300), $(this).html('<span class="glyphicon glyphicon-menu-up"></span>'), $(".chapter").css("margin-top", "0"), $.removeCookie("hidenav-cookie", { path: "/" }))
    : ($(".navbar").slideUp(300), $(this).html('<span class="glyphicon glyphicon-menu-down"></span>'), $(".chapter").css("margin-top", "10px"), $.cookie("hidenav-cookie", 1, { expires: 365, path: "/" }));
});
 $('input[name="fluid-switch"]').click(function () {
    "yes" == this.value
    ? ($(".chapter").removeClass("container").addClass("container-fluid"), $.cookie("fluid-switch-cookie", 1, { expires: 365, path: "/" }))
    : ($(".chapter").removeClass("container-fluid").addClass("container"), $.removeCookie("fluid-switch-cookie", { path: "/" }));
});
 $('input[name="onebreak-switch"]').click(function () {
    "yes" == this.value
    ? ($(".chapter-c").html(
      $(".chapter-c")
      .html()
      .replace(/(<br\s*\/?>\s*\n?(&nbsp;)?){2,}/gi, "<br>")
      ),
    $.cookie("onebreak-switch-cookie", 1, { expires: 365, path: "/" }))
    : (original_content && $(".chapter-c").html(original_content), $.removeCookie("onebreak-switch-cookie", { path: "/" }));
});
 $(document).keydown(function (a) {
    !1 !== $("input[type='text'], input[type='search']").is(":focus") ||
    a.ctrlKey ||
    (37 == a.which || 65 == a.which
        ? $("#prev_chap")[0].click()
        : 39 == a.which || 68 == a.which
        ? $("#next_chap")[0].click()
        : 83 == a.which
        ? ((a = $(window).scrollTop()), $(window).scrollTop(a + 37))
        : 87 == a.which && ((a = $(window).scrollTop()), $(window).scrollTop(a - 37)));
});
 $(".chapter-nav").on("click", "button.chapter_jump", function () {
    $("button.chapter_jump").attr("disabled", !0);
    var chap = $("#chapter-id").val();
    $.post("/wp-admin/admin-ajax.php", { 'action' : 'tw_ajax', 'type':'list_chap', 'chap' : chap, 'id' : $("#id_post").val() }).done(function (a) {
        $(".chapter_jump").replaceWith(a);
    });
});
 $(".chapter-nav").on("click", "button#chapter_error", function() {
    var a = prompt("Vui l\u00f2ng m\u00f4 t\u1ea3 l\u1ed7i:", "");
    if (null === a || !1 === a) return !1;
    "" === a ? alert("B\u1ea1n ch\u01b0a nh\u1eadp m\u00f4 t\u1ea3. B\u00e1o l\u1ed7i kh\u00f4ng th\u00e0nh c\u00f4ng!") : ($("button#chapter_error").addClass("hide"), $.post("", {
        type: "chapter_error",
        title: document.title,
        id: $("#chapter-id").val(),
        message: a
    }), alert("C\u1ea3m \u01a1n b\u1ea1n \u0111\u00e3 b\u00e1o nha!"))
})
var href = window.location.href;
 $(".chapter-nav").on("click", "button#chapter_comment", function () {
    load_comment("fb-comment-chapter", href);
});
 "*Ch\u01b0\u01a1ng n\u00e0y c\u00f3 n\u1ed9i dung \u1ea3nh, n\u1ebfu b\u1ea1n kh\u00f4ng th\u1ea5y n\u1ed9i dung ch\u01b0\u01a1ng, vui l\u00f2ng b\u1eadt ch\u1ebf \u0111\u1ed9 hi\u1ec7n h\u00ecnh \u1ea3nh c\u1ee7a tr\u00ecnh duy\u1ec7t \u0111\u1ec3 \u0111\u1ecdc." ===
 $(".chapter-c").text() && $(".chapter-c").addClass("no-br");