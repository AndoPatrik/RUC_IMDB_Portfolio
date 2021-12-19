import { postData } from "../httpRequest.js";

var SignUpViewModel = function () {
    var self = this;

    var validBoolean = function (value) {
        return typeof value === 'boolean';
    };
    this.passwordsMatch = ko.observable(true, validBoolean);

    this.showPasswordsMatchError = ko.computed(function () {
        return !self.passwordsMatch() && self.validPassword();
    });


    self.username = ko.observable("").extend({ required: true });
    self.password = ko.observable("").extend({
        required: true,
        pattern: {
            message: "Password must have at least one number and one letter",
            params: /^(?=.*[0-9])(?=.*[a-zA-Z])[A-Za-z0-9]+$/
        }
    });
    self.passwordConfirm = ko.observable("").extend({
        required: true,
        //areSame: self.password,
        validate: function (value) {
            return value === self.password();
        },
        flag: self.passwordsMatch
    });

    self.handleSubmit = async function () {
        var errors = ko.validation.group(self);
        if (errors().length > 0) {
            errors.showAllMessages();
            console.log("handle error")
            return;

        }

        const payload = {
            username: self.username(),
            password: self.password()
        }

        var result = await postData('/Users/register', payload);
        console.log(result)

        if (result.message.includes('created')) {
            history.back();
        } else {
            self.username("");
            self.password("");
            self.passwordConfirm("");
            alert("Something went wrong. Try again.");
        }

    }

    self.handleBack = function () {
        history.back();
    }

    ko.validation.rules['areSame'] = {
        getValue: function (o) {
            return (typeof o === 'function' ? o() : o);
        },
        validator: function (val, otherField) {
            return val === this.getValue(otherField);
        },
        message: 'The fields must have the same value'
    };

    ko.validation.registerExtenders();
};

ko.applyBindings(new SignUpViewModel());