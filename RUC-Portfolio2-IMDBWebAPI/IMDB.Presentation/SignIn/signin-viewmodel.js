import { postData } from "../httpRequest.js";

var SignInViewModel = function () {
    var self = this;

    self.username = ko.observable("").extend({ required: true });
    self.password = ko.observable("").extend({
        required: true
    });


    self.handleSubmit = async function () {

        var errors = ko.validation.group(self);
        if (errors().length > 0) {
            errors.showAllMessages();
            return;
        }

        const payload = {
            username: self.username(),
            password: self.password()
        }

        var result = await postData('/Auth', payload);

        if (result.data) {
            sessionStorage.setItem("CurrentUser", JSON.stringify({ user: self.username(), token: result.data.token }))
            // window.location.href = "./index.html"
            history.back()
        }

        self.username("");
        self.password("");
    }

    self.handleBack = function () {
        history.back();
    }
};

ko.applyBindings(new SignInViewModel());
