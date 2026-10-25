// @ts-check
const eslint = require("@eslint/js");
const { defineConfig } = require("eslint/config");
const tseslint = require("typescript-eslint");
const angular = require("angular-eslint");

module.exports = defineConfig([
  {
    files: ["**/*.ts"],
    extends: [
      eslint.configs.recommended,
      tseslint.configs.recommended,
      tseslint.configs.stylistic,
      angular.configs.tsRecommended,
    ],
    processor: angular.processInlineTemplates,
    rules: {
      "@angular-eslint/prefer-inject": "warn",
      "@angular-eslint/prefer-standalone": "warn",
      "@angular-eslint/prefer-on-push-component-change-detection": "warn",
      "@angular-eslint/directive-selector": [
        "warn",
        {
          type: "attribute",
          prefix: "app",
          style: "camelCase",
        },
      ],
      "@angular-eslint/component-selector": [
        "warn",
        {
          type: "element",
          prefix: "app",
          style: "kebab-case",
        },
      ],
      "@angular-eslint/no-empty-lifecycle-method": "warn",
      "@angular-eslint/no-input-rename": "warn",
      "@typescript-eslint/consistent-generic-constructors": "warn",
      "@typescript-eslint/consistent-indexed-object-style": "warn",
      "@typescript-eslint/consistent-type-assertions": "warn",
      "@typescript-eslint/no-empty-function": "warn",
      "@typescript-eslint/no-explicit-any": "warn",
      "@typescript-eslint/no-inferrable-types": "warn",
      "@typescript-eslint/no-unused-vars": "warn",
      "@typescript-eslint/prefer-for-of": "warn",
      "no-prototype-builtins": "warn",
      "no-self-assign": "warn",
      "no-useless-assignment": "warn",
      "no-var": "warn",
      "prefer-const": "warn",
    },
  },
  {
    files: ["**/*.html"],
    extends: [
      angular.configs.templateRecommended,
      angular.configs.templateAccessibility,
    ],
    rules: {
      "@angular-eslint/template/alt-text": "warn",
      "@angular-eslint/template/eqeqeq": "warn",
      "@angular-eslint/template/label-has-associated-control": "warn",
      "@angular-eslint/template/no-negated-async": "warn",
      "@angular-eslint/template/prefer-control-flow": "warn",
    },
  }
]);
