(function () {
    'use strict';

    describe("String Extensions", function () {

        describe("Capitalise", function () {

            it('should capitalise only first character', function () {
                expect('original string'.capitalise()).toBe('Original string');
            });


            it('should handle null and empty values', function () {
                var s = new String();
                expect(s.capitalise()).toEqual(s);
                expect(''.capitalise()).toBe('');
            });
        });


        describe("camelCaseToSpineCase", function () {

            it('should produce the correct result', function () {
                expect('someCamelCase'.camelCaseToSpineCase()).toBe('some-camel-case');
            });

            it('should handle whitespace', function () {
                expect('some-CamelCase with Space'.camelCaseToSpineCase()).toBe('some-camel-case-with-space');
            });

            it('should handle digits', function () {
                expect('s0m3C4m31C4s3'.camelCaseToSpineCase()).toBe('s0m3-c4m31-c4s3');
            });

            it('should handle null and empty values', function () {
                var s = new String();
                expect(s.camelCaseToSpineCase()).toEqual(s);
                expect(''.camelCaseToSpineCase()).toBe('');
            });
        });


        describe("spineCaseToCamelCase", function () {

            it('should convert snake case to camelcase', function () {
                expect('some-snake-Case'.spineCaseToCamelCase()).toBe('someSnakeCase');
            });

            it('should handle whitespace', function () {
                expect('  some snakeCase with Space '.spineCaseToCamelCase()).toBe('someSnakeCaseWithSpace');
            });

            it('should handle digits', function () {
                expect('s0m3-5n4k3-C4s3'.spineCaseToCamelCase()).toBe('s0m35n4k3C4s3');
            });

            it('should handle null and empty values', function () {
                var s = new String();
                expect(s.spineCaseToCamelCase()).toEqual(s);
                expect(''.spineCaseToCamelCase()).toBe('');
            });
        });

        describe("format", function () {

            it('should handle a string with no arguments', function () {
                expect('string without any arguments'.format()).toBe('string without any arguments');
            });

            it('should handle a string with only one argument', function () {
                expect('string with {0} argument'.format('one')).toBe('string with one argument');
            });

            it('should handle a string with more than one argument', function () {
                expect('string with {0}, {1}, {2} or more arguments'.format('one', 'two', 'three')).toBe('string with one, two, three or more arguments');
            });

            it('should handle a number as an argument', function () {
                expect('string with the number {0} in it.'.format(1)).toBe('string with the number 1 in it.');
            });

            it('should handle null and empty values', function () {
                var s = new String();
                expect(s.format('test')).toEqual(s);
                expect(''.format('test')).toBe('');
            });
        });
    });

})();