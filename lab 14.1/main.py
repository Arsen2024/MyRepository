import pandas as pd

df = pd.read_csv("brands.csv")

print(df.head())
print(df.tail())
print(df.shape)
print(df.columns)
print(df.dtypes)
print(df.loc[0])
print(df.iloc[0, 1])
print(df.describe())
print(df['name'].value_counts())
print(df['facebook_followers'].unique())
print(df.corr(numeric_only=True))
print(df.sample(6))